using Newtonsoft.Json;

namespace MaybeArchitecture.Plugins.MovieProvider.Tmdb.Models
{
    public class TmdbMovie
    {
        public string Title { get; set; }
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public double Popularity { get; set; }
    }
}
