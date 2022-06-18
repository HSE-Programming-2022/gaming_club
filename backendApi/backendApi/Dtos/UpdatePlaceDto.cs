using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record UpdatePlaceDto
    {
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

    }
}