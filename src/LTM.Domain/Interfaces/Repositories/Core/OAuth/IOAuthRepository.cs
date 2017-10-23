using LTM.Domain.Entities.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace LTM.Domain.Interfaces.Repositories
{
    public interface IOAuthRepository
    {
        /// <summary>
        /// Registra um usuário no sistema
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task RegisterUser(User user);

        /// <summary>
        /// Busca um usuário no sistema
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
