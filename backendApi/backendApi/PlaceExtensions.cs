using backendApi.Dtos;
using backendApi.Entities;

namespace backendApi
{
    public static class PlaceExtensions
    {
        public static PlaceDto AsDto(this Place place)
        {
            return new PlaceDto
            {
                Id = place.Id,
                Price = place.Price,
                RowNumber = place.RowNumber,
                SeatNumber = place.SeatNumber,
                HallNumber = place.HallNumber,
                Description = place.Description,
                Type = place.Type
            };
        }
    }
}