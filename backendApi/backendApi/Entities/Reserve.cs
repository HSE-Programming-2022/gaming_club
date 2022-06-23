using System;

namespace backendApi.Entities
{
    public class Reserve
    {
        public Guid Id { get; init; }
        public User User { get; init; }
        public Tariff Tariff { get; init; }
        public Place Place { get; init; }
        
        public DateTime StartTime { get; init; }
        
        public DateTime FinishTime { get; init; }
    }
}