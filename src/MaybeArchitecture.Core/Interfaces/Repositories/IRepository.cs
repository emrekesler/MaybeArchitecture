using MaybeArchitecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<bool> AddRangeAsync(List<T> items);
        Task<bool> UpdateAsync(T item);
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetListAsync(bool asNoTracking = true);
        Task<int> CountAsync();
        Task<bool> IfExitsAsync(int id);
    }
}
