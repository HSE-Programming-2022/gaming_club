using System;

namespace backendApi.Entities
{
    public record Place
    {
        public Guid Id { get; init; }

        public decimal Price { get; set; }

        public int RowNumber { get; init; }

        public int SeatNumber { get; init; }

        public string Description { get; set; }

        public int Number { get; init; }

        public string Type { get; set; }

    }
}
