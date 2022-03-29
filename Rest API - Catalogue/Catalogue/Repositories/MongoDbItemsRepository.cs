using Catalogue.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        //The name of the DB
        private const string DatabaseName = "catalog";
        private const string CollectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient) 
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            itemsCollection = database.GetCollection<Item>(CollectionName);

        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();         
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }
    }
}
