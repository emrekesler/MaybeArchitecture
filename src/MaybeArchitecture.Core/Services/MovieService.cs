using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using MaybeArchitecture.Core.Interfaces.Services;
using MaybeArchitecture.Core.Models;
using MaybeArchitecture.Core.Models.Dtos;
using MaybeArchitecture.Mapper;
using MaybeArchitecture.Plugins.MovieProvider;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Services
{
    public class MovieService : Service<Movie, MovieDto>, IMovieService
    {
        private readonly IMovieProvider _movieProvider;
        public MovieService(ILogger<MovieService> logger, IMovieRepository repository, IMapper mapper, IMovieProvider movieProvider) : base(logger, repository, mapper)
        {
            _movieProvider = movieProvider;
        }

        public async Task<Response> ImportFromProvider()
        {
            try
            {
                var movies = await _movieProvider.GetAsync();
                bool response = false;

                if (movies != null && movies.Any())
                {
                    response = await Repository.AddRangeAsync(Mapper.Map<List<Movie>>(movies));
                }

                return new Response(isSuccess: response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Import Movie Exeption");
                return new Response();
            }
        }
    }
}
