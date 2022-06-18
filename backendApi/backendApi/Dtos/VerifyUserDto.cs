using System;
using System.ComponentModel.DataAnnotations;

namespace backendApi.Dtos
{
    public class VerifyUserDto
    {
        [Required]
        public string Email { get; init; }
        
        [Required]
        public string Password { get; init; }
    }
}