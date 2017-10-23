using LTM.Application.Interfaces.Core;
using LTM.Domain.Interfaces.Repositories;
using LTM.Application.Mapper;
using LTM.Domain.Entities.Core;
using LTM.Application.Models.Core.OAuth;

using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;


namespace LTM.Application.App.Core
{
    public class OAuthApp : IOAuthApp
    {
        private readonly IOAuthRepository _oauthRepository;
        private readonly IAutoMapperAdapter _mapper;
        public OAuthApp(IOAuthRepository oauthRepository, IAutoMapperAdapter mapper)
        {
            _oauthRepository = oauthRepository;
            _mapper = mapper;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            try
            {
                return await _oauthRepository.FindUser(userName, password);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RegisterUser(UserModel userModel)
        {
            try
            {
                User userDomain = _mapper.Adapt<UserModel,User>(userModel);
                await _oauthRepository.RegisterUser(userDomain);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
