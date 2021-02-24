using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using MaybeArchitecture.Core.Interfaces.Services;
using MaybeArchitecture.Core.Models;
using MaybeArchitecture.Core.Models.Dtos;
using MaybeArchitecture.Mapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaybeArchitecture.Core.Services
{
    public class Service<T, TDto> : IService<TDto> where T : BaseEntity, new() where TDto : BaseDto, new()
    {
        private protected readonly ILogger Logger;
        private protected readonly IRepository<T> Repository;
        private protected readonly IMapper Mapper;

        public Service(ILogger logger, IRepository<T> repository, IMapper mapper)
        {
            Logger = logger;
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<Response<TDto>> AddAsync(TDto item)
        {
            T entity = Mapper.Map<T>(item);

            bool result = await Repository.AddAsync(entity);

            if (result)
            {
                return new Response<TDto>
                {
                    Data = Mapper.Map<TDto>(entity),
                    IsSuccess = true
                };
            }

            return new Response<TDto>
            {
                Data = item,
                IsSuccess = false,
                Message = "Something went wrong"
            };
        }

        public async Task<Response<TDto>> AddRangeAsync(List<TDto> items)
        {
            List<T> entitys = Mapper.Map<List<T>>(items);

            bool result = await Repository.AddRangeAsync(entitys);

            if (result)
            {
                return new Response<TDto>
                {
                    Data = Mapper.Map<TDto>(entitys),
                    IsSuccess = true
                };
            }

            return new Response<TDto>
            {
                IsSuccess = false,
                Message = "Something went wrong"
            };
        }

        public async Task<Response<int>> CountAsync()
        {
            return new Response<int>
            {
                Data = await Repository.CountAsync()
            };
        }

        public virtual async Task<Response<TDto>> GetAsync(int id)
        {
            T item = await Repository.GetAsync(id);

            if (item != null)
            {
                return new Response<TDto>
                {
                    Data = Mapper.Map<TDto>(item),
                    IsSuccess = true
                };
            }

            return new NotFoundResponse<TDto>();
        }

        public virtual async Task<Response<IReadOnlyList<TDto>>> GetAsync()
        {
            IReadOnlyList<T> items = await Repository.GetListAsync();

            if (items != null)
            {
                return new Response<IReadOnlyList<TDto>>
                {
                    Data = Mapper.Map<IReadOnlyList<TDto>>(items),
                    IsSuccess = true
                };
            }

            return new NotFoundResponse<IReadOnlyList<TDto>>();
        }

        public async Task<Response<bool>> IfExitsAsync(int id)
        {
            return new Response<bool>
            {
                Data = await Repository.IfExitsAsync(id)
            };
        }

        public virtual async Task<Response<TDto>> UpdateAsync(TDto item)
        {
            T entity = await Repository.GetAsync(item.Id);

            if (entity == null)
            {
                return new NotFoundResponse<TDto>()
                {
                    Data = item
                };
            }

            Mapper.Map(item, entity);

            bool result = await Repository.UpdateAsync(entity);

            item = Mapper.Map<TDto>(entity);

            return new Response<TDto>
            {
                Data = item,
                IsSuccess = result
            };
        }
    }
}
