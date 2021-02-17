using MaybeArchitecture.Mapper;
using MaybeArchitecture.Plugins.MovieProvider.Models;
using MaybeArchitecture.Plugins.MovieProvider.Tmdb.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaybeArchitecture.Plugins.MovieProvider.Tmdb
{
    internal class MovieProvider : IMovieProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly string _apiKey;
        public MovieProvider(HttpClient httpClient, IMapper mapper, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _mapper = mapper;

            _httpClient.BaseAddress = new Uri(configuration["Tmdb:BaseUrl"]);
            _apiKey = configuration["Tmdb:ApiKey"];
        }

        public async Task<List<Movie>> GetAsync()
        {
            List<TmdbMovie> movies = new List<TmdbMovie>();

            TmdbResult result = await GetResult();

            if (result != null && result.Results.Any())
            {
                movies.AddRange(result.Results);

                if (result.TotalPages > 1)
                {
                    for (int i = 2; i < result.TotalPages; i++)
                    {
                        TmdbResult result2 = await GetResult(i);

                        movies.AddRange(result2.Results);
                    }
                }
            }

            return _mapper.Map<List<Movie>>(movies);
        }

        private async Task<TmdbResult> GetResult(int page = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"3/movie/popular?api_key={_apiKey}&page={page}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TmdbResult>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
    }
}
