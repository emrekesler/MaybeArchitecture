using System.Collections.Generic;

namespace MaybeArchitecture.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<WhiteList> WhiteLists { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
