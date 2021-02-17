using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace MaybeArchitecture.Infrastructure.Data.EF.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext managementDbContext, ILogger<MovieRepository> logger) : base(managementDbContext, logger)
        {
        }
    }
}
