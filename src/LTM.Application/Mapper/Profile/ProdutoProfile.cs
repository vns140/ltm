using AutoMapper;
using LTM.Application.Models;
using LTM.Domain.Entities;

namespace LTM.Application.Mapper
{
    public class ProdutoProfile: Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoModel>();

            CreateMap<ProdutoModel, Produto>().ConstructUsing(p => Produto
                .Factory(p.Nome,p.Descricao,p.CustoUnitario,p.PrecoVenda,p.Id));
        }
    }
}
