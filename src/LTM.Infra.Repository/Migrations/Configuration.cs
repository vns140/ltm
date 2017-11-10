namespace LTM.Infra.Repository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LTM.Infra.Repository.Context.ContextOAuth>
    {
        public Configuration():base()
        {
            AutomaticMigrationsEnabled = true;
            
        }

        //protected override void Seed(LTM.Infra.Repository.Context.ContextOAuth context)
        //{
        //    base.Seed(context);
            
        //    UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>(context));
        //    Domain.Entities.Core.User user = new Domain.Entities.Core.User { UserName = "ltm", Password = "123456", ConfirmPassword = "123456" };

        //    IdentityUser userIdentity = new IdentityUser
        //    {
        //        UserName = user.UserName
        //    };

        //    _userManager.Create(userIdentity, user.Password);

        //}
    }
}
