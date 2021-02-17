using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using MaybeArchitecture.Core.Interfaces.Services;
using MaybeArchitecture.Core.Models;
using MaybeArchitecture.Core.Models.Dtos;
using MaybeArchitecture.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Services
{
    public class UserService : Service<User, UserDto>, IUserService
    {
        public UserService(ILogger<UserService> logger, IUserRepository repository, IMapper mapper) : base(logger, repository, mapper)
        {
        }

        public Task<Response<bool>> AddWhiteList(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
