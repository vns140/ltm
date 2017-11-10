
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LTM.Infra.Repository.Context
{
    public class ContextOAuth: IdentityDbContext<IdentityUser>
    {
        public ContextOAuth() : base("AuthContext")
        {
            InitializeDatabase();
        }

        protected virtual void InitializeDatabase()
        {
            if (!Database.Exists())
            {
                Database.Initialize(true);
                Seed(this);
            }
        }

        protected void Seed(LTM.Infra.Repository.Context.ContextOAuth context)
        {
            

            UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>(context));
            Domain.Entities.Core.User user = new Domain.Entities.Core.User { UserName = "ltm", Password = "123456", ConfirmPassword = "123456" };

            IdentityUser userIdentity = new IdentityUser
            {
                UserName = user.UserName
            };

            _userManager.Create(userIdentity, user.Password);

        }
    }
}
