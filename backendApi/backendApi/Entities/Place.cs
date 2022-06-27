using System;

namespace backendApi.Entities
{
    public record Place
    {
        public Guid Id { get; init; }

        public decimal Price { get; init; }

        public int RowNumber { get; init; }

        public int SeatNumber { get; init; }

        public string Description { get; init; }

        public int Number { get; init; }

        public string Type { get; init; }

    }
}
