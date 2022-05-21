using System;

namespace backendApi.Dtos
{
    public record UserDto
    {
        public Guid Id { get; init; }
        
        public string Name { get; init; }
        
        public string Surname { get; init; }
        
        public string Password { get; init; }
        
        public decimal Balance { get; init; }
        
        public DateTimeOffset CreatedDate { get; init; }
    }
}