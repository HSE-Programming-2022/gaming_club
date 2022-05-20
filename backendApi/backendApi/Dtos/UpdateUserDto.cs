using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        public string Name { get; init; }
        
        [Required]
        public string Surname { get; init; }
        
        [Required]
        [Range(0, 1000000)]
        public decimal Balance { get; init; }
    }
}