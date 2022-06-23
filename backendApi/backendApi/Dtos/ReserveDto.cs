using System;

namespace backendApi.Dtos
{
    public record ReserveDto
    {
        public Guid Id { get; init; }
        
        public string UserCredentials { get; init; }

        public int PlaceRow { get; init; }
        
        public int PlaceNumber { get; init; }
        
        public DateTime StartTime { get; init; }
        
        public DateTime FinishTime { get; init; }
    }
}