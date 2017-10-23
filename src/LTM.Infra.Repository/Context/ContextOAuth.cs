
using Microsoft.AspNet.Identity.EntityFramework;

namespace LTM.Infra.Repository.Context
{
    public class ContextOAuth: IdentityDbContext<IdentityUser>
    {
        public ContextOAuth() : base("AuthContext")
        {

        }
    }
}
