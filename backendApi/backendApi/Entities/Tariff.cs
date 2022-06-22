using System;

namespace backendApi.Entities
{
    public record Tariff
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public decimal SessionPrice { get; set; }

        public int Hours { get; init; }

        public int BlockTimeStart { get; set; }

        public int BlockTimeEnd { get; set; }

        public string Type { get; init; }

    }
}