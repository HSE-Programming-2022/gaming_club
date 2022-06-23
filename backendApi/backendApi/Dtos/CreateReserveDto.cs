using System;
using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record CreateReserveDto
    {
        [Required]
        public Guid UserId { get; init; }
        public Guid PlaceId { get; init; }
        public string StartTime { get; init; }
        public string FinishTime { get; init; }
    }
}