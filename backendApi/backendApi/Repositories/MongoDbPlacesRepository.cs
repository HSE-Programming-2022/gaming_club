using System;
using System.Collections.Generic;
using backendApi.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backendApi.Repositories
{
    public class MongoDbPlacesRepository : IPlacesRepository
    {

        private const string databaseName = "backendapi";

        private const string collectionName = "places";

        private readonly IMongoCollection<Place> placesCollection;

        private readonly FilterDefinitionBuilder<Place> filterBuilder = Builders<Place>.Filter;

        public MongoDbPlacesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            placesCollection = database.GetCollection<Place>(collectionName);
        }
        public void CreatePlace(Place place)
        {
            placesCollection.InsertOne(place);
        }

        public void DeletePlace(Guid id)
        {
            var filter = filterBuilder.Eq(place => place.Id, id);
            placesCollection.DeleteOne(filter);
        }

        public Place GetPlace(Guid id)
        {
            var filter = filterBuilder.Eq(place => place.Id, id);
            return placesCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Place> GetPlaces()
        {
            return placesCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdatePlace(Place place)
        {
            var filter = filterBuilder.Eq(existingPlace => existingPlace.Id, place.Id);
            placesCollection.ReplaceOne(filter, place);
        }
    }
}