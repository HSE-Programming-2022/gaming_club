using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record CreatePlaceDto
    {
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 50)]
        public int RowNumber { get; init; }

        [Required]
        [Range(1, 50)]
        public int SeatNumber { get; init; }

        [Required]
        [Range(1, 5)]
        public int HallNumber { get; init; }

        [Required]
        public string Type { get; set; }

        public string Description { get; set; }
    }
}