using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IFacultyService
{
    
}

public class FacultyService (IRepositoryManager repositoryManager, ILogger logger) : IFacultyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILogger _logger = logger;
}