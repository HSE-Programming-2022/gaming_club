using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public record UpdateTariffDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal SessionPrice { get; set; }

        [Required]
        [Range(0, 24)]
        public int BlockTimeStart { get; set; }

        [Required]
        [Range(1, 24)]
        public int BlockTimeEnd { get; set; }
    }
}