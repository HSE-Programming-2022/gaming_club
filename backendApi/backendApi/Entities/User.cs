using System;

namespace backendApi.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        
        public string Name { get; init; }
        
        public string Surname { get; init; }
        
        public string Password { get; init; }
        
        public string Email { get; init; }
        
        public string PhoneNumber { get; init; }
        
        public decimal Balance { get; init; }
        
        public DateTimeOffset CreatedDate { get; init; }
    }
}