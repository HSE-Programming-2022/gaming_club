using System;
using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record CreateReserveDto
    {
        [Required]
        public Guid UserId { get; init; }
        [Required]
        public Guid PlaceId { get; init; }
        [Required]
        public string StartTime { get; init; }
        [Required]
        public string FinishTime { get; init; }
        public DateTime CreatedTime { get; init; }
    }
}