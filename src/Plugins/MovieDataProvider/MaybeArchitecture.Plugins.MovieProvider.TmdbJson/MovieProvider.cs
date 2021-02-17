using MaybeArchitecture.Plugins.MovieProvider.Models;
using MaybeArchitecture.Plugins.MovieProvider.TmdbJson.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MaybeArchitecture.Plugins.MovieProvider.TmdbJson
{
    internal class MovieProvider : IMovieProvider
    {
        private readonly Settings _settings;
        private readonly ILogger _logger;

        public MovieProvider(IOptions<Settings> options, ILogger<MovieProvider> logger)
        {
            _settings = options.Value;
            _logger = logger;
        }

        public async Task<List<Movie>> GetAsync()
        {
            try
            {
                string fileContent = await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, _settings.FileName));
                return JsonConvert.DeserializeObject<List<Movie>>(fileContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tmdb Json Provider Error");
                return new List<Movie>();
            }
        }
    }
}
