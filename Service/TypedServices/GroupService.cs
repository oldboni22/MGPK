using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IGroupService
{
    
}

public class GroupService (IRepositoryManager repositoryManager, IMapper mapper, ILogger<GroupService> logger) : IGroupService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GroupService> _logger = logger;
}