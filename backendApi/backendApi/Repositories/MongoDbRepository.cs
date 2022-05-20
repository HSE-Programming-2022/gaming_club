using System;
using System.Collections.Generic;
using MongoDB.Driver;
using backendApi.Entities;
using MongoDB.Bson;

namespace backendApi.Repositories
{
    public class MongoDbRepository : IUsersRepository
    {
        private const string databaseName = "backend";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        public MongoDbRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }
        
        public IEnumerable<User> GetUsers()
        {
            return usersCollection.Find(new BsonDocument()).ToList();
        }

        public User GetUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return usersCollection.Find(filter).SingleOrDefault();
        }

        public void CreateUser(User user)
        {
            usersCollection.InsertOne(user);
        }

        public void UpdateUser(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            usersCollection.ReplaceOne(filter, user);
        }

        public void DeleteUser(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            usersCollection.DeleteOne(filter);
        }
    }
}