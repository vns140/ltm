using LTM.Application.App;
using LTM.Application.Interfaces;
using LTM.Application.Models;
using LTM.Infra.CrossCutting.Operations;

using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace LTM.Barramento.Controllers
{
    //[Authorize]
    public class ProdutosController : ApiController
    {
        private readonly IProdutoApp _produtoApp;

        public ProdutosController()
        {
            _produtoApp = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProdutoApp)) as ProdutoApp;
        }

        // GET: api/Produtos
        public async Task<IHttpActionResult> Get()
        {
            var response  = await _produtoApp.Get();

            if (response.OperationResult.Status == StatusOperation.ERRORRESULT)
            {
                return InternalServerError(new Exception(response.OperationResult.Message));
            }

            return Ok(response.Data);
        }

        // GET: api/Produtos/5
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var response = await _produtoApp.GetById(id);

            if (response.OperationResult.Status == StatusOperation.ERRORRESULT)
            {
                return InternalServerError(new Exception(response.OperationResult.Message));
            }

            return Ok(response.Data);
        }

        // POST: api/Produtos
        public async Task<IHttpActionResult> Post([FromBody]ProdutoModel produto)
        {
            var response = await _produtoApp.Add(produto);

            if (response.OperationResult.Status == StatusOperation.ERRORRESULT)
            {
                return InternalServerError(new Exception(response.OperationResult.Message));
            }

            return Ok(response);
        }

        // PUT: api/Produtos/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]ProdutoModel produto)
        {
            var response = await _produtoApp.Update(produto);

            if (response.OperationResult.Status == StatusOperation.ERRORRESULT)
            {
                return InternalServerError(new Exception(response.OperationResult.Message));
            }

            return Ok(response);
        }

        // DELETE: api/Produtos/5
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var response = await _produtoApp.Remove(id);

            if (response.OperationResult.Status == StatusOperation.ERRORRESULT)
            {
                return InternalServerError(new Exception(response.OperationResult.Message));
            }

            return Ok(response);
        }
    }
}
