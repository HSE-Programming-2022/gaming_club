using System;
using System.Collections.Generic;
using backendApi.Entities;

namespace backendApi.Repositories
{
    public interface IPlacesRepository
    {
        Place GetPlace(Guid id);

        IEnumerable<Place> GetPlaces();

        void CreatePlace(Place place);

        void UpdatePlace(Place place);

        void DeletePlace(Guid id);
    }

}