using System;
using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record CheckAvailabilityReserveDto
    {
        [Required]
        public Guid PlaceId { get; init; }
        [Required]
        public string StartTime { get; init; }
        [Required]
        public string FinishTime { get; init; }
    }
}