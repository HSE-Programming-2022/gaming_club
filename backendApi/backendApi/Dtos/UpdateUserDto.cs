using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        public string Email { get; init; }
        
        [Required]
        [Range(0, 1000000)]
        public decimal Balance { get; init; }
    }
}