using LTM.Domain.Interfaces.Repositories;
using LTM.Infra.Repository.Repositories.Core;
using LTM.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LTM.Infra.Repository.Repositories
{
    public class ProdutoRepository : RepositoryBase, IProdutoRepository
    {

        public ProdutoRepository():base()
        {

        }

        public async Task<Guid> Add(Produto produto)
        {
            try
            {
                await Db.Produtos.InsertOneAsync(produto);
                return produto.Id;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task Update(Produto produto)
        {
            try
            {
                var filter = Builders<Produto>.Filter.Eq(p => p.Id, produto.Id);
                var update = Builders<Produto>.Update
                    .Set(p => p.PrecoVenda, produto.PrecoVenda)
                    .Set(p => p.CustoUnitario, produto.CustoUnitario)
                    .Set(p => p.Descricao, produto.Descricao)
                    .Set(p => p.PrecoVenda, produto.PrecoVenda);

                await Db.Produtos.UpdateOneAsync(filter, update);

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<Produto>> Get(int limit, int offset)
        {
            try
            {
                return await Db.Produtos.AsQueryable().Skip(offset)
                    .Take(limit).ToListAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<Produto> GetById(Guid id)
        {
            try
            {
                return await Db.Produtos.AsQueryable().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task Remove(Guid id)
        {
            try
            {
                await Db.Produtos.DeleteOneAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex) { throw ex; }
        }
        
    }
}
