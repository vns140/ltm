using LTM.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTM.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="poduto">Produto a ser inserido</param>
        /// <returns>identificação do produto a ser inserido</returns>
        Task<Guid> Add(Produto poduto);

        /// <summary>
        /// Atualiza um produto na base de dados
        /// </summary>
        /// <param name="produto">Produto a ser atualizado</param>
        Task Update(Produto produto);

        /// <summary>
        /// Obtêm uma lista de produtos paginados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Produto>> Get();

        /// <summary>
        /// Obtêm um produto pela identificação
        /// </summary>
        /// <param name="id">identificação do produto</param>
        /// <returns>Produto</returns>
        Task<Produto> GetById(Guid id);

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Identificação do produto</param>
        Task Remove(Guid id);
    }
}
