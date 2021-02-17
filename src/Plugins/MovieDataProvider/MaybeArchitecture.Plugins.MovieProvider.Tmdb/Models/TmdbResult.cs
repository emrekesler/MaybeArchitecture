using Newtonsoft.Json;
using System.Collections.Generic;

namespace MaybeArchitecture.Plugins.MovieProvider.Tmdb.Models
{
    public class TmdbResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("results")]
        public List<TmdbMovie> Results { get; set; }
    }
}
