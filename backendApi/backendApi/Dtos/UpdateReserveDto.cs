using System;
using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record UpdateReserveDto
    {
        [Required]
        [Range(1, 50)]
        public int PlaceRow { get; init; }
        
        [Required]
        [Range(1, 50)]
        public int PlaceSeat { get; init; }
        
        [Required]
        [Range(1, 100)]
        public int PlaceNumber { get; init; }
        
        public DateTime StartTime { get; init; }
        
        public DateTime FinishTime { get; init; }

        public DateTime CreatedTime { get; init; }

    }
}