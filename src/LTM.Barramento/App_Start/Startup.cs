using LTM.Application.Interfaces.Core;
using LTM.Barramento.Dependency;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


[assembly: OwinStartup(typeof(LTM.Barramento.App_Start.Startup))]
namespace LTM.Barramento.App_Start
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            Container container = new Container();
            container = SimpleInjectorWebApiInitializer.Initialize(container);
            ConfigureOAuth(app, container);
            HttpConfiguration config = new HttpConfiguration();
            SwaggerConfig.RegisterSwagger(config);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, Container container)
        {
            using (AsyncScopedLifestyle.BeginScope(container))
            {

                var authApp = container.GetInstance(typeof(IOAuthApp)) as IOAuthApp;
                OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/api/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new SimpleAuthorizationServerProvider(authApp)
                };
                app.UseOAuthAuthorizationServer(OAuthServerOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            }           
         
        }

    }
}