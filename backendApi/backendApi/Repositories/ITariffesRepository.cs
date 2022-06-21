using System;
using System.Collections.Generic;
using backendApi.Entities;

namespace backendApi.Repositories
{
    public interface ITariffesRepository
    {
        Tariff GetTariff(Guid id);

        Tariff GetTariffByHoursBlockTimeStartBlockTimeEndType(int hours, int blockTimeStart, int blockTimeEnd, string Type);

        IEnumerable<Tariff> GetTariffes();

        void CreateTariff(Tariff tariff);

        void UpdateTariff(Tariff tariff);

        void DeleteTariff(Guid id);
    }

}