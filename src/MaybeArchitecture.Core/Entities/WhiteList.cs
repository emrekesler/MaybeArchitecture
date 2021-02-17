using System.Collections.Generic;

namespace MaybeArchitecture.Core.Entities
{
    public class WhiteList : BaseEntity
    {
        public WhiteList()
        {
            Movies = new List<Movie>();
        }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
