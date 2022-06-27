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
        private readonly IPlacesRepository repositoryPlaces;
        private readonly ITariffesRepository repositoryTariffes;

        public ReserveController(IReserveRepository repository,
            IUsersRepository repositoryUsers,
            IPlacesRepository repositoryPlaces,
            ITariffesRepository repositoryTariffes)
        {
            this.repository = repository;
            this.repositoryUsers = repositoryUsers;
            this.repositoryPlaces = repositoryPlaces;
            this.repositoryTariffes = repositoryTariffes;
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

            if (!repository.CheckAvailability(startTime, finishTime, reserveDto.PlaceId))
            {
                return Conflict();
            }

            Reserve reserve = new()
            {
                User = repositoryUsers.GetUser(reserveDto.UserId),
                Place = repositoryPlaces.GetPlace(reserveDto.PlaceId),
                StartTime = startTime,
                FinishTime = finishTime,
                CreatedTime = DateTime.Now
            };

            var cost = CostCalculation(reserve);

            if (reserve.User.Balance < cost)
            {
                return Conflict();
            }

            var newBalance = reserve.User.Balance - cost;

            User updatedUser = reserve.User with
            {
                Balance = newBalance
            };

            repository.CreateReserve(reserve);
            repositoryUsers.UpdateUser(updatedUser);
            return CreatedAtAction(nameof(GetReserve), new {id = reserve.Id}, reserve.AsDto());
        }

        [HttpGet("by_user/{id}")]
        public IEnumerable<ReserveDto> GetReservesByUser(Guid id)
        {
            return repository.GetReserves().Where(reserve => reserve.User.Id == id)
                .Select(item => item.AsDto());
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateReserve(Guid id, UpdateReserveDto reserveDto)
        {
            var existingReserve = repository.GetReserve(id);

            if (existingReserve is null)
            {
                return NotFound();
            }

            var place = repositoryPlaces.GetPlaceByNumberRowSeat(reserveDto.PlaceNumber, reserveDto.PlaceRow,
                reserveDto.PlaceSeat);

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

        [HttpPost("cost")]
        public ActionResult<decimal> CalculateCost(CreateReserveDto reserveDto)
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
            
            Reserve reserve = new()
            {
                User = repositoryUsers.GetUser(reserveDto.UserId),
                Place = repositoryPlaces.GetPlace(reserveDto.PlaceId),
                StartTime = startTime,
                FinishTime = finishTime,
                CreatedTime = DateTime.Now
            };

            decimal cost = CostCalculation(reserve);

            return cost;
        }

        [HttpPost("is_available")]
        public ActionResult CheckAvailability(CheckAvailabilityReserveDto reserveDto)
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

            if (!repository.CheckAvailability(startTime, finishTime, reserveDto.PlaceId))

            {
                return Conflict();
            }

            return Ok();
        }
    }
}