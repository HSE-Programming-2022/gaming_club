using System;

namespace backendApi.Entities
{
    public record Reserve
    {
        public Guid Id { get; init; }
        
        public User User { get; init; }
        
        public Place Place { get; init; }
        
        public DateTime CreatedTime { get; init; }
        
        public DateTime StartTime { get; init; }
        
        public DateTime FinishTime { get; init; }

        public decimal Cost { get; set; }
    }
}