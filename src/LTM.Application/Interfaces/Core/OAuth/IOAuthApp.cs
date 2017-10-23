using LTM.Application.Models.Core.OAuth;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace LTM.Application.Interfaces.Core
{
    public interface IOAuthApp
    {
        Task RegisterUser(UserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
