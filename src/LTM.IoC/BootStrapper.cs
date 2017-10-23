using LTM.Application.App;
using LTM.Application.App.Core;
using LTM.Application.Interfaces;
using LTM.Application.Interfaces.Core;
using LTM.Application.Mapper;
using LTM.Domain.Interfaces.Repositories;
using LTM.Infra.Repository.Repositories;
using SimpleInjector;


namespace LTM.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoApp, ProdutoApp>(Lifestyle.Scoped);
            container.Register<IOAuthApp, OAuthApp>(Lifestyle.Scoped);
            container.Register<IOAuthRepository, OAuthRepository>(Lifestyle.Scoped);

            #region Mapper
            var mapperConfig = AutoMapperConfig.GetMapperConfiguration();
            container.RegisterSingleton(mapperConfig);
            container.Register(() => mapperConfig.CreateMapper(), Lifestyle.Singleton);
            container.Register<IAutoMapperAdapter, AutoMapperAdapter>(Lifestyle.Singleton);
            #endregion
        }
    }
}
