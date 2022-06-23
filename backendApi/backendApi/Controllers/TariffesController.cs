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
    [Route("tariffes")]
    public class TariffesController : ControllerBase
    {
        private readonly ITariffesRepository repository;

        public TariffesController(ITariffesRepository repository)
        {
            this.repository = repository;
        }

        // GET /tariffes
        [HttpGet]
        public IEnumerable<TariffDto> GetTariffes()
        {
            var tariffes = repository.GetTariffes().Select( tariff => tariff.AsDto());
            return tariffes;
        }

        // GET /tariffes/{id}
        [HttpGet("{id}")]
        public ActionResult<TariffDto> GetTariff(Guid id)
        {
            var tariff = repository.GetTariff(id);

            if (tariff is null)
            {
                return NotFound();
            }

            return tariff.AsDto();
        }

        // POST /tariffes
        [HttpPost]
        
        public ActionResult<TariffDto> CreateTariff(CreateTariffDto tariffDto)
        {
            if (repository.GetTariffByHoursBlockTimeStartBlockTimeEndType(tariffDto.Hours,
                                                                          tariffDto.BlockTimeStart,
                                                                          tariffDto.BlockTimeEnd,
                                                                          tariffDto.Type) is not null ||
                tariffDto.BlockTimeStart >= tariffDto.BlockTimeEnd)
            {
                return Conflict();
            }

            Tariff tariff = new()
            {
                Id = Guid.NewGuid(),
                Name = tariffDto.Name,
                SessionPrice = tariffDto.SessionPrice,
                Hours = tariffDto.Hours,
                BlockTimeStart = tariffDto.BlockTimeStart,
                BlockTimeEnd = tariffDto.BlockTimeEnd,
                Type = tariffDto.Type
            };

            repository.CreateTariff(tariff);

            return CreatedAtAction(nameof(GetTariff), new {id = tariff.Id}, tariff.AsDto());
        }
        
        // PUT /tariffes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTariff(Guid id, UpdateTariffDto tariffDto)
        {
            var existingTariff = repository.GetTariff(id);

            if (existingTariff is null)
            {
                return NotFound();
            }

            Tariff updatedTariff = existingTariff with 
            {
                Name = tariffDto.Name,
                SessionPrice = tariffDto.SessionPrice,
                BlockTimeStart = tariffDto.BlockTimeStart,
                BlockTimeEnd = tariffDto.BlockTimeEnd,
            };

            repository.UpdateTariff(updatedTariff);

            return NoContent();

        }

        // DELETE /tariffes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTariff(Guid id)
        {
            var existingTariff = repository.GetTariff(id);

            if (existingTariff is null)
            {
                return NotFound();
            }

            repository.DeleteTariff(id);

            return NoContent();

        }
    }
}