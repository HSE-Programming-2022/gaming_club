using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record UpdatePlaceDto
    {
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

    }
}