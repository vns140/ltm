using LTM.Domain.Entities;

using MongoDB.Driver;
using System;
using System.Collections.Generic;

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

            
            Produto produto = Produto.Factory("Bola de Futebol", "Bola Nike, numero 5 e formato campo.", 10, 20, Guid.Empty);
            Produto produto2 = Produto.Factory("Mesa Praia", "plastico, 120x20.", 100, 200, Guid.Empty);
            Produto produto3 = Produto.Factory("Cadeira Madeira", "Rústica, 120x20.", 120, 240, Guid.Empty);
            Produto produto4 = Produto.Factory("Mouse Microsoft", "scroll top, cor azul.", 27, 62, Guid.Empty);

            List<Produto> produtos = new List<Produto> { produto, produto2, produto3, produto4 };

            if(!Produtos.AsQueryable().Any())
            {
                Produtos.InsertMany(produtos);
            }
        }
    }
}
