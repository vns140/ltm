using LTM.Application.Models.Core.OAuth;
using LTM.Domain.Entities.Core;

using AutoMapper;
namespace LTM.Application.Mapper
{
    public class OAuthProfile : Profile
    {
        public OAuthProfile()
        {
            CreateMap<User, UserModel>();

            CreateMap<UserModel, User>();
        }
    }
}
