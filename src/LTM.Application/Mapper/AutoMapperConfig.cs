using AutoMapper;

namespace LTM.Application.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProdutoProfile>();
                cfg.AddProfile<OAuthProfile>();
            });
            return mapperConfiguration;
        }
    }
}
