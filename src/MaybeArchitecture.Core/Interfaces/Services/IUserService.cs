using MaybeArchitecture.Core.Models;
using MaybeArchitecture.Core.Models.Dtos;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Interfaces.Services
{
    public interface IUserService : IService<UserDto>
    {
        Task<Response<bool>> AddWhiteList(int userId, int movieId);
    }
}
