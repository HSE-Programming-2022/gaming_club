using System;
using System.Collections.Generic;
using backendApi.Dtos;
using System.Linq;
using backendApi.Entities;
using backendApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backendApi.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReserveController : ControllerBase
    {
        private readonly IReserveRepository repository;
        private readonly IUsersRepository repositoryUsers;
        private readonly ITariffesRepository repositoryTariffes;
        private readonly IPlacesRepository repositoryPlaces;

        public ReserveController(IReserveRepository repository, 
                                IUsersRepository repositoryUsers,
                                ITariffesRepository repositoryTariffes,
                                IPlacesRepository repositoryPlaces)
        {
            this.repository = repository;
            this.repositoryUsers = repositoryUsers;
            this.repositoryTariffes = repositoryTariffes;
            this.repositoryPlaces = repositoryPlaces;
        }

        private decimal CostCalculation(Reserve reserve)
        {
            var createdTime = reserve.CreatedTime.Hour;
            var hours = (reserve.FinishTime - reserve.StartTime).Hours;
            var placeType = reserve.Place.Type;
            var neededTariffes = repositoryTariffes.GetTariffes().Where(tariff => tariff.Type == placeType && 
                                                                                 (tariff.BlockTimeStart <= createdTime &&
                                                                                  tariff.BlockTimeEnd > createdTime))
                                                                 .OrderByDescending(tariff => tariff.Hours);
            decimal cost = 0;

            while (hours != 0)
            {
                foreach (var tariff in neededTariffes)
                {
                    if (tariff.Hours > hours)
                    {
                        continue;
                    }
                    else
                    {
                        hours -= tariff.Hours;
                        cost += tariff.SessionPrice;
                    }
                }
            }

            return cost;
        }


        [HttpGet]
        public IEnumerable<ReserveDto> GetReserves()
        {
            var items = repository.GetReserves().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ReserveDto> GetReserve(Guid id)
        {
            var reserve = repository.GetReserve(id);
            if (reserve is null)
            {
                return NotFound();
            }

            return reserve.AsDto();
        }

        [HttpPost]
        public ActionResult<ReserveDto> CreateReserve(CreateReserveDto reserveDto)
        {
            DateTime startTime; 
            DateTime finishTime;
            try
            {
                startTime = DateTime.Parse(reserveDto.StartTime);
                finishTime = DateTime.Parse(reserveDto.FinishTime);
            }
            catch (FormatException e)
            {
                return UnprocessableEntity();
            }
             
            // DateTime startDate, DateTime finishTime, int row, int seat
            if (!repository.CheckAvailability(startTime, finishTime, reserveDto.PlaceId))
            {
                Conflict();
            }

            Reserve reserve = new()
            {
                User = repositoryUsers.GetUser(reserveDto.UserId),
                Place = repositoryPlaces.GetPlace(reserveDto.PlaceId),
                StartTime = startTime,
                FinishTime = finishTime,
                CreatedTime = DateTime.Now
            };
            repository.CreateReserve(reserve);
            return CreatedAtAction(nameof(GetReserve), new {id = reserve.Id}, reserve.AsDto());
        }

        [HttpGet("by_user/{id}")]
        public IEnumerable<ReserveDto> GetReservesByUser(Guid id)
        {
            return repository.GetReserves().Where(reserve => reserve.User.Id == id)
                .Select(item => item.AsDto());
        }

        // PUT /reserves/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateReserve(Guid id, UpdateReserveDto reserveDto)
        {
            var existingReserve = repository.GetReserve(id);

            if (existingReserve is null)
            {
                return NotFound();
            }

            var place = repositoryPlaces.GetPlaceByNumberRowSeat(reserveDto.PlaceNumber, reserveDto.PlaceRow, reserveDto.PlaceSeat);

            Reserve updatedReserve = existingReserve with
            {
                Place = place,
                StartTime = reserveDto.StartTime,
                FinishTime = reserveDto.FinishTime,
                CreatedTime = DateTime.Now
            };

            repository.UpdateReserve(updatedReserve);

            return NoContent();

        }

        [HttpPost("cost/{id}")]
        public ActionResult<decimal> CalculateCost(Guid id)
        {
            var existingReserve = repository.GetReserve(id);

            if (existingReserve is null)
            {
                return NotFound();
            }

            decimal cost = CostCalculation(existingReserve);

            if (cost == 0)
            {
                return Conflict();
            }

            return cost;
        }

        [HttpPost("payment/{id}")]
        public ActionResult PayForReserve(Guid id)
        {
            var existingReserve = repository.GetReserve(id);

            decimal cost = CostCalculation(existingReserve);

            if (existingReserve is null)
            {
                return NotFound();
            }

            if (cost == 0 | existingReserve.User.Balance < cost)
            {
                return Conflict();
            }

            var newBalance = existingReserve.User.Balance - cost;

            User updatedUser = existingReserve.User with
            {
                Balance = newBalance
            };

            repositoryUsers.UpdateUser(updatedUser);

            return NoContent();
        }
    }
}