using System;

namespace MaybeArchitecture.Core.Models.Dtos
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
