using System;

namespace MaybeArchitecture.Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Active = true;
            CreateAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
