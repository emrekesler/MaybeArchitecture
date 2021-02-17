namespace MaybeArchitecture.Core.Models.Dtos
{
    public class CommentDto : BaseDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public MovieDto Movie { get; set; }
        public UserDto User { get; set; }
    }
}
