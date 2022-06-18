using System;

namespace backendApi.Dtos
{
    public record PlaceDto
    {
        public Guid Id { get; init; }

        public decimal Price { get; set; }

        public int RowNumber { get; init; }

        public int SeatNumber { get; init; }

        public string Description { get; set; }

        public int HallNumber { get; init; }

        public string Type { get; set; }

    }
}
