using LTM.Application.Models;
using LTM.Infra.CrossCutting.Operations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTM.Application.Interfaces
{
    public interface IProdutoApp
    {

        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="poduto">Produto a ser inserido</param>
        /// <returns>identificação do produto a ser inserido</returns>
        Task<ResponseBase> Add(ProdutoModel poduto);

        /// <summary>
        /// Atualiza um produto na base de dados
        /// </summary>
        /// <param name="produto">Produto a ser atualizado</param>
        Task<ResponseBase> Update(ProdutoModel produto);

        /// <summary>
        /// Obtêm uma lista de produtos paginados
        /// </summary>
        /// <param name="limit">Quantidade de itens por retorno</param>
        /// <param name="offset">Deslocamento</param>
        /// <returns></returns>
        Task<ResponseCore<IEnumerable<ProdutoModel>>> Get(int limit, int offset);

        /// <summary>
        /// Obtêm um produto pela identificação
        /// </summary>
        /// <param name="id">identificação do produto</param>
        /// <returns>Produto</returns>
        Task<ResponseCore<ProdutoModel>> GetById(Guid id);

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Identificação do produto</param>
        Task<ResponseBase> Remove(Guid id);
    }
}
