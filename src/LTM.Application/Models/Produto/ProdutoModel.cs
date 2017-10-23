
using LTM.Application.Models.Core;

namespace LTM.Application.Models
{
    public class ProdutoModel : EntityBaseModel
    {
        #region properties
        public string Nome { get;  set; }

        public string Descricao { get;  set; }

        public decimal CustoUnitario { get;  set; }

        public decimal PrecoVenda { get;  set; }
        #endregion
    }
}
