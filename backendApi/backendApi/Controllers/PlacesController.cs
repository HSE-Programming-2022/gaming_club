using Microsoft.AspNetCore.Mvc;
using backendApi.Repositories;
using System.Collections.Generic;
using backendApi.Entities;
using backendApi.Dtos;
using System;
using System.Linq;

namespace backendApi.Controllers
{
    [ApiController]
    [Route("places")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesRepository repository;

        public PlacesController(IPlacesRepository repository)
        {
            this.repository = repository;
        }

        // GET /places
        [HttpGet]
        public IEnumerable<PlaceDto> GetPlaces()
        {
            var places = repository.GetPlaces().Select( place => place.AsDto());
            return places;
        }

        // GET /places/{id}
        [HttpGet("{id}")]
        public ActionResult<PlaceDto> GetPlace(Guid id)
        {
            var place = repository.GetPlace(id);

            if (place is null)
            {
                return NotFound();
            }

            return place.AsDto();
        }

        // POST /places
        [HttpPost]
        
        public ActionResult<PlaceDto> CreatePlace(CreatePlaceDto placeDto)
        {
            if (repository.GetPlaceByHallRowSeat(placeDto.HallNumber, placeDto.RowNumber, placeDto.SeatNumber) is not null)
            {
                return Conflict();
            }
            Place place = new()
            {
                Id = Guid.NewGuid(),
                Price = placeDto.Price,
                RowNumber = placeDto.RowNumber,
                SeatNumber = placeDto.SeatNumber,
                HallNumber = placeDto.HallNumber,
                Description = placeDto.Description,
                Type = placeDto.Type
            };

            repository.CreatePlace(place);

            return CreatedAtAction(nameof(GetPlace), new {id = place.Id}, place.AsDto());
        }
        
        // PUT /places/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlace(Guid id, UpdatePlaceDto placeDto)
        {
            var existingPlace = repository.GetPlace(id);

            if (existingPlace is null)
            {
                return NotFound();
            }

            Place updatedPlace = existingPlace with 
            {
                Price = placeDto.Price,
                Description = placeDto.Description,
                Type = placeDto.Type
            };

            repository.UpdatePlace(updatedPlace);

            return NoContent();

        }

        // DELETE /placed/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlace(Guid id)
        {
            var existingPlace = repository.GetPlace(id);

            if (existingPlace is null)
            {
                return NotFound();
            }

            repository.DeletePlace(id);

            return NoContent();

        }
    }
}