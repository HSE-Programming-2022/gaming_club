using backendApi.Dtos;
using backendApi.Entities;

namespace backendApi
{
    public static class ReserveExtensions
    {
        public static ReserveDto AsDto(this Reserve reserve)
        {
            return new ReserveDto
            {
                Id = reserve.Id,
                UserCredentials = reserve.User.Name + " " + reserve.User.Surname,
                TariffName = reserve.Tariff.Name,
                PlaceRow = reserve.Place.RowNumber,
                PlaceNumber = reserve.Place.SeatNumber,
                StartTime = reserve.StartTime,
                FinishTime = reserve.FinishTime
            };
        }
    }
}