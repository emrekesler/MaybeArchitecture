using MaybeArchitecture.Plugins.MovieProvider.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaybeArchitecture.Plugins.MovieProvider
{
    public interface IMovieProvider
    {
        Task<List<Movie>> GetAsync();
    }
}
