using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace MaybeArchitecture.Infrastructure.Data.EF.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext managementDbContext, ILogger<CommentRepository> logger) : base(managementDbContext, logger)
        {
        }
    }
}
