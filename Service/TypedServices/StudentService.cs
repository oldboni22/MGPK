using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IStudentService
{
    
}

public class StudentService (IRepositoryManager repositoryManager, ILogger logger) : IStudentService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILogger _logger = logger;
}