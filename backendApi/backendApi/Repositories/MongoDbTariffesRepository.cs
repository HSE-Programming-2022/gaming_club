using System;
using System.Collections.Generic;
using backendApi.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backendApi.Repositories
{
    public class MongoDbTariffesRepository : ITariffesRepository
    {

        private const string databaseName = "backendapi";

        private const string collectionName = "tariffes";

        private readonly IMongoCollection<Tariff> tariffesCollection;

        private readonly FilterDefinitionBuilder<Tariff> filterBuilder = Builders<Tariff>.Filter;

        public MongoDbTariffesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            tariffesCollection = database.GetCollection<Tariff>(collectionName);
        }
        public void CreateTariff(Tariff tariff)
        {
            tariffesCollection.InsertOne(tariff);
        }

        public void DeleteTariff(Guid id)
        {
            var filter = filterBuilder.Eq(tariff => tariff.Id, id);
            tariffesCollection.DeleteOne(filter);
        }

        public Tariff GetTariff(Guid id)
        {
            var filter = filterBuilder.Eq(tariff => tariff.Id, id);
            return tariffesCollection.Find(filter).SingleOrDefault();
        }

        public Tariff GetTariffByHoursBlockTimeStartBlockTimeEndType(int hours, int blockTimeStart, int blockTimeEnd, string type)
        {
            var filterHours = filterBuilder.Eq(tariff => tariff.Hours, hours);
            var filterBlockTimeStart = filterBuilder.Eq(tariff => tariff.BlockTimeStart, blockTimeStart);
            var filterBlockTimeEnd = filterBuilder.Eq(tariff => tariff.BlockTimeEnd, blockTimeEnd);
            var filterType = filterBuilder.Eq(tariff => tariff.Type, type);
            var filter = Builders<Tariff>.Filter.And(new List<FilterDefinition<Tariff>>{ filterHours, filterBlockTimeStart, filterBlockTimeEnd, filterType});

            return tariffesCollection.Find(filter).SingleOrDefault();
        }


        public IEnumerable<Tariff> GetTariffes()
        {
            return tariffesCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateTariff(Tariff tariff)
        {
            var filter = filterBuilder.Eq(existingTariff => existingTariff.Id, tariff.Id);
            tariffesCollection.ReplaceOne(filter, tariff);
        }
    }
}