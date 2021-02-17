namespace MaybeArchitecture.Core.Models.Dtos
{
    public class MovieDto : BaseDto
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public double Popularity { get; set; }
    }
}
