using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ReserveController(IReserveRepository repository, 
                                IUsersRepository repositoryUsers,
                                IPlacesRepository repositoryPlaces)
        {
            this.repository = repository;
            this.repositoryUsers = repositoryUsers;
            this.repositoryPlaces = repositoryPlaces;
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
                FinishTime = finishTime
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