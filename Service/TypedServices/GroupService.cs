using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IGroupService
{
    
}

public class GroupService (IRepositoryManager repositoryManager, ILogger logger) : IGroupService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILogger _logger = logger;
}