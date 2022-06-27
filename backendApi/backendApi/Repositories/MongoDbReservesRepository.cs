using System;
using System.Collections;
using System.Collections.Generic;
using backendApi.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backendApi.Repositories
{
    public class MongoDbReservesRepository: IReserveRepository
    {
        private const string databaseName = "backend";
        private const string collectionName = "reserves";
        private readonly IMongoCollection<Reserve> reservesCollection;
        private readonly FilterDefinitionBuilder<Reserve> filterBuilder = Builders<Reserve>.Filter;

        public MongoDbReservesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            reservesCollection = database.GetCollection<Reserve>(collectionName);
        }

        public bool CheckAvailability(DateTime startDate, DateTime finishTime, Guid placeId)
        {
            var filter = filterBuilder.Where(reserve =>
                reserve.Place.Id == placeId &&
                reserve.StartTime < finishTime &&
                reserve.FinishTime > startDate);
            var reserve = reservesCollection.Find(
                filter
            ).SingleOrDefault();
            Console.WriteLine(reserve);
            return reserve is null;
        }

        public IEnumerable<Reserve> GetReserves()
        {
            return reservesCollection.Find(new BsonDocument()).ToList();
        }

        public Reserve GetReserve(Guid id)
        {
            var filter = filterBuilder.Eq(reserve => reserve.Id, id);
            return reservesCollection.Find(filter).SingleOrDefault();
        }

        public void CreateReserve(Reserve reserve)
        {
            reservesCollection.InsertOne(reserve);
        }

        public void UpdateReserve(Reserve reserve)
        {
            var filter = filterBuilder.Eq(existingReserve => existingReserve.Id, reserve.Id);
            reservesCollection.ReplaceOne(filter, reserve);
        }

        public void DeleteReserve(Reserve reserve)
        {
            var filter = filterBuilder.Eq(existingReserve => existingReserve.Id, reserve.Id);
            reservesCollection.DeleteOne(filter);
        }
        
    }
}