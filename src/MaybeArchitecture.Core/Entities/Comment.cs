namespace MaybeArchitecture.Core.Entities
{
    public class Comment : BaseEntity
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
