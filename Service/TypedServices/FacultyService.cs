using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service.TypedServices;

public interface IFacultyService
{
    IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges);
}

public class FacultyService (IRepositoryManager repositoryManager, IMapper mapper) : IFacultyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager; 
    private readonly IMapper _mapper = mapper;

    public IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges)
    {
        var faculties = _repositoryManager.Faculty.FindAll(trackChanges);
        var facultiesDto = _mapper.Map<IEnumerable<FacultyDto>>(faculties);

        return facultiesDto;
    }


}