using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace MaybeArchitecture.Infrastructure.Data.EF.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext managementDbContext, ILogger<UserRepository> logger) : base(managementDbContext, logger)
        {
        }
    }
}
