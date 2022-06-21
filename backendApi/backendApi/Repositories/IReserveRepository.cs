using System;
using System.Collections;
using System.Collections.Generic;
using backendApi.Dtos;
using backendApi.Entities;

namespace backendApi.Repositories
{
    public interface IReserveRepository
    {
        IEnumerable<Reserve> GetReserves();

        Reserve GetReserve(Guid id);

        void CreateReserve(Reserve reserve);
        
        void UpdateReserve(Reserve reserve);
        
        void DeleteReserve(Reserve reserve);

        bool CheckAvailability(DateTime startDate, DateTime finishTime, Guid placeId);
    }
}