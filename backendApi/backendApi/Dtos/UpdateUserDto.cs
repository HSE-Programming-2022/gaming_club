using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public class UpdateUserDto
    {
        public string Email { get; init; }
        
        [Range(-100000, 1000000)]
        public decimal Balance { get; init; }
    }
}