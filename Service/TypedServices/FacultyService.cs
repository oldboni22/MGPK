using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service;

public interface IFacultyService
{
    IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges);
}

public class FacultyService (IRepositoryManager repositoryManager, IMapper mapper,ILogger<FacultyService> logger) : IFacultyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager; 
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<FacultyService> _logger = logger;
    
    public IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges)
    {
        try
        {
            var faculties = _repositoryManager.Faculty.FindAll(trackChanges);
            var facultiesDto = _mapper.Map<IEnumerable<FacultyDto>>(faculties);
            
            return facultiesDto;
        }
        catch (Exception e)
        {
            throw;
        }
    }


}