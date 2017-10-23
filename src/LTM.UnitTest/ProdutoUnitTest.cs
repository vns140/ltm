using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LTM.Infra.Repository.Repositories;
using LTM.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LTM.ProdutoUnitTest
{
    [TestClass]
    public class ProdutoUnitTest
    {
        [TestMethod]
        public async Task DeveInserirUmProduto()
        {
            //arrange
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto produto = Produto.Factory("Bola de Futebol", "Bola Nike, numero 5 e formato campo.", 10, 20, Guid.Empty);

            //act
            Guid id= await produtoRepository.Add(produto);

            //assert
            Assert.AreNotEqual(Guid.Empty, id);
        }

        [TestMethod]
        public async Task DeveAtualizarUmProduto()
        {
            //arrange
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto produto = Produto.Factory("Bola de Futebol", "Bola Nike, numero 5 e formato campo.", 10, 20, new Guid(""));

            //act
            await produtoRepository.Update(produto);

            //assert
            
        }

        [TestMethod]
        public async Task DeveObterUmProduto()
        {
            //arrange
            ProdutoRepository produtoRepository = new ProdutoRepository();

            //act
            Produto produto = await produtoRepository.GetById(new Guid(""));

            //assert
            Assert.IsNotNull(produto);
        }

        [TestMethod]
        public async Task DeveObterVariosProdutos()
        {
            //arrange
            ProdutoRepository produtoRepository = new ProdutoRepository();

            //act
            IEnumerable<Produto> produtos = await produtoRepository.Get(0,10);

            //assert
            Assert.IsNotNull(produtos);
        }

        [TestMethod]
        public async Task DeveRemoverUmProduto()
        {
            //arrange
            ProdutoRepository produtoRepository = new ProdutoRepository();
           
            //act
            await produtoRepository.Remove(new Guid(""));

            //assert
        }
    }
}
