using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using LTM.Infra.Repository.Repositories;

namespace LTM.UnitTest
{
    /// <summary>
    /// Autorizacao
    /// </summary>
    [TestClass]
    public class OAuthUnitTest
    {
        public OAuthUnitTest()
        {

        }

        [TestMethod]
        public async Task DeveRegistrarUmUsuario()
        {
            OAuthRepository oauthRepository = new OAuthRepository();
            await oauthRepository.RegisterUser(new Domain.Entities.Core.User { UserName = "vns140", Password = "123456", ConfirmPassword = "123456" });
        }


        [TestMethod]
        public async Task DeveObterUmUsuario()
        {
            OAuthRepository oauthRepository = new OAuthRepository();
            await oauthRepository.FindUser("","");
        }
    }
}
