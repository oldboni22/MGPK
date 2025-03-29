using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service;

public interface IFacultyService
{
    IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges);
}

public class FacultyService (IRepositoryManager repositoryManager, ILogger logger,IMapper mapper) : IFacultyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILogger _logger = logger;
    private readonly IMapper _mapper = mapper;
    
    public IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges)
    {
        try
        {
            var faculties = _repositoryManager.Faculty.FindAll(trackChanges);
            var facultiesDto = _mapper.Map<IEnumerable<FacultyDto>>(faculties);
            
            _logger.LogInformation("Successfully fetched faculties!");
            return facultiesDto;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"An exception occured while fetching faculties!");
            throw;
        }
    }


}