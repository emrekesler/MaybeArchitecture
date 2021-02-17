namespace MaybeArchitecture.Plugins.MovieProvider.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public double Popularity { get; set; }
    }
}
