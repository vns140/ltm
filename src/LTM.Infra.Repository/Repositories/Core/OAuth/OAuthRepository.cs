using LTM.Domain.Entities.Core;
using LTM.Domain.Interfaces.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace LTM.Infra.Repository.Repositories
{
    public class OAuthRepository : IDisposable, IOAuthRepository
    {
        private Repository.Context.ContextOAuth _ctx;

        private UserManager<IdentityUser> _userManager;

        public OAuthRepository()
        {
            _ctx = new Repository.Context.ContextOAuth();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task RegisterUser(User user)
        {
            IdentityUser userIdentity = new IdentityUser
            {
                UserName = user.UserName
            };

            await _userManager.CreateAsync(userIdentity, user.Password);            
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
