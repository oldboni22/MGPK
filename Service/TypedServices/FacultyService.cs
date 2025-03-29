using Entities;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IFacultyService
{
    IEnumerable<Faculty> FindAll(bool trackChanges);
}

public class FacultyService (IRepositoryManager repositoryManager, ILogger logger) : IFacultyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILogger _logger = logger;

    public IEnumerable<Faculty> FindAll(bool trackChanges)
    {
        try
        {
            var faculties = _repositoryManager.Faculty.FindAll(trackChanges);
            
            _logger.LogInformation("Successfully fetched faculties!");
            return faculties;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"An exception occured while fetching faculties!");
            throw;
        }
    }


}