using AutoMapper;
using Entities;
using Entities.Exceptions.NotFound;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service.TypedServices;

public interface IFacultyService
{
    IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges);
    FacultyDto? GetFaculty(int id,bool trackChanges);
}

public class FacultyService (IRepositoryManager repositoryManager, IMapper mapper) : IFacultyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager; 
    private readonly IMapper _mapper = mapper;

    public IEnumerable<FacultyDto> GetAllFaculties(bool trackChanges)
    {
        var faculties = _repositoryManager.Faculty.GetAllFaculties(trackChanges);
        var facultiesDto = _mapper.Map<IEnumerable<FacultyDto>>(faculties);

        return facultiesDto;
    }

    public FacultyDto? GetFaculty(int id, bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(id, trackChanges);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(id);
        }

        var dto = _mapper.Map<FacultyDto>(faculty);
        return dto;
    }





}