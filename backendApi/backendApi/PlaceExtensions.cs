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
                RowNumber = place.RowNumber,
                SeatNumber = place.SeatNumber,
                Number = place.Number,
                Description = place.Description,
                Type = place.Type
            };
        }
    }
}