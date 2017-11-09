using LTM.Application.App.Core;
using LTM.Application.Interfaces.Core;
using LTM.Application.Models.Core.OAuth;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace LTM.Barramento.Controllers
{

    [RoutePrefix("api/contas")]
    public class ContasController : ApiController
    {
        private readonly IOAuthApp _authApp;


        public ContasController()
        {
            _authApp = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IOAuthApp)) as OAuthApp;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IHttpActionResult> Post([FromBody] UserModel userModel)
        {
            if (userModel == null)
                return BadRequest("Null entity");

            try
            {
                 await _authApp.RegisterUser(userModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            finally
            {

            }
        }

        
    }
}
