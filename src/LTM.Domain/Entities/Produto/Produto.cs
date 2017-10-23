using LTM.Domain.Entities.Core;
using System;

namespace LTM.Domain.Entities
{
    /// <summary>
    /// Classe de produto, representa todos os produtos cadastrados na empresa.
    /// </summary>
    public class Produto : EntityBase
    {
        #region properties
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public decimal CustoUnitario { get; private set; }

        public decimal PrecoVenda { get; private set; }
        #endregion

        #region constructors
        private Produto(string nome, string descricao, decimal custoUnitario, decimal precoVenda, Guid id) : base(id)
        {
            Nome = nome;
            Descricao = descricao;
            CustoUnitario = custoUnitario;
            PrecoVenda = precoVenda;
        }
        #endregion

        #region factories
        public static Produto Factory(string nome, string descricao, decimal custoUnitario, decimal precoVenda, Guid id)
        {
            Produto produto = new Produto(nome, descricao, custoUnitario, precoVenda, id);
            return produto;
        }
        #endregion
    }
}
