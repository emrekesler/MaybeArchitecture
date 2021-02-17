using MaybeArchitecture.Core.Models;
using MaybeArchitecture.Core.Models.Dtos;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Interfaces.Services
{
    public interface IMovieService : IService<MovieDto>
    {
        Task<Response> ImportFromProvider();
    }
}
