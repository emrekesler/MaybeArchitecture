using MaybeArchitecture.Core.Models;
using MaybeArchitecture.Core.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Interfaces.Services
{
    public interface IService<TDto> where TDto : BaseDto, new()
    {
        Task<Response<TDto>> AddAsync(TDto item);
        Task<Response<TDto>> AddRangeAsync(List<TDto> items);
        Task<Response<TDto>> UpdateAsync(TDto item);
        Task<Response<TDto>> GetAsync(int id);
        Task<Response<IReadOnlyList<TDto>>> GetAsync();
        Task<Response<int>> CountAsync();
        Task<Response<bool>> IfExitsAsync(int id);
    }
}
