using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IGroupService
{
    
}

public class GroupService (IRepositoryManager repositoryManager, ILogger logger, IMapper mapper) : IGroupService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILogger _logger = logger;
    private readonly IMapper _mapper = mapper;
}