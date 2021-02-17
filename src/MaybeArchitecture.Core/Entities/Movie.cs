using System.Collections.Generic;

namespace MaybeArchitecture.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public double Popularity { get; set; }

        public List<Comment> Comments { get; set; }
        public List<WhiteList> WhiteLists { get; set; }
    }
}
