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
                PlaceRow = reserve.Place.RowNumber,
                PlaceSeat = reserve.Place.SeatNumber,
                PlaceNumber = reserve.Place.Number,
                CreatedTime = reserve.CreatedTime,
                StartTime = reserve.StartTime,
                FinishTime = reserve.FinishTime,
                Cost = reserve.Cost
            };
        }
    }
}