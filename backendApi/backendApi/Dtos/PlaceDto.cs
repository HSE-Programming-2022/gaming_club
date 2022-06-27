using System;

namespace backendApi.Dtos
{
    public record PlaceDto
    {
        public Guid Id { get; init; }

        public int RowNumber { get; init; }

        public int SeatNumber { get; init; }

        public string Description { get; init; }

        public int Number { get; init; }

        public string Type { get; init; }

    }
}
