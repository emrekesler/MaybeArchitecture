using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using MaybeArchitecture.Core.Interfaces.Services;
using MaybeArchitecture.Core.Models.Dtos;
using MaybeArchitecture.Mapper;
using Microsoft.Extensions.Logging;

namespace MaybeArchitecture.Core.Services
{
    public class CommentService : Service<Comment, CommentDto>, ICommentService
    {
        public CommentService(ILogger<CommentService> logger, ICommentRepository repository, IMapper mapper) : base(logger, repository, mapper)
        {
        }
    }
}
