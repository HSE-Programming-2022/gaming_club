using System;

namespace backendApi.Dtos
{
    public record TariffDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal SessionPrice { get; init; }

        public int Hours { get; init; }

        public int BlockTimeStart { get; init; }

        public int BlockTimeEnd { get; init; }

        public string Type { get; init; }

    }
}