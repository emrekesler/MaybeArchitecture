using System.Collections.Generic;

namespace MaybeArchitecture.Core.Models.Dtos
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<MovieDto> WhiteList { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
