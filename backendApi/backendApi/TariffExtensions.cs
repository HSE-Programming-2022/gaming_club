using backendApi.Dtos;
using backendApi.Entities;

namespace backendApi
{
    public static class TariffExtensions
    {
        public static TariffDto AsDto(this Tariff tariff)
        {
            return new TariffDto
            {
                Id = tariff.Id,
                Name = tariff.Name,
                SessionPrice = tariff.SessionPrice,
                Hours = tariff.Hours,
                BlockTimeStart = tariff.BlockTimeStart,
                BlockTimeEnd = tariff.BlockTimeEnd,
                Type = tariff.Type
            };
        }
    }
}