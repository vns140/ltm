using LTM.Domain.Entities;

using MongoDB.Driver;
using System;

namespace LTM.Infra.Repository
{
    public class ContextProduto : NoSqlContext
    {        

        #region properties
        public IMongoDatabase db { get; set; }

        public IMongoCollection<Produto> Produtos { get; set; }
        #endregion

        #region constructors
        public ContextProduto() : base("MongoContext", "MongoBase")
        {
            OnModelCreating();
        }
        #endregion

        public override void OnModelCreating()
        {
            string connectionString = Configuration;
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.ServerSelectionTimeout = TimeSpan.FromMinutes(2);
            MongoClient mongoClient = new MongoClient(settings);
            db = mongoClient.GetDatabase(Database);


            Produtos = db.GetCollection<Produto>("Produtos");
        }
    }
}
