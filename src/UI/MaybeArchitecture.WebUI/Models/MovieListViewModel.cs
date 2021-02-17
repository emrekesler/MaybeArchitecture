using MaybeArchitecture.Core.Models.Dtos;
using System.Collections.Generic;

namespace MaybeArchitecture.WebUI.Models
{
    public class MovieListViewModel
    {
        public IReadOnlyList<MovieDto> Movies { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }
}
