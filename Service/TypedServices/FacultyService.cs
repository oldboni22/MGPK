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
    IEnumerable<FacultyDto> GetFacultiesById(IEnumerable<int> ids,bool trackChanges);
    
    FacultyDto? GetFaculty(int id,bool trackChanges);
    FacultyDto CreateFaculty(FacultyCreationDto faculty);
    (IEnumerable<FacultyDto> faculties,string ids) CreateFaculties(IEnumerable<FacultyCreationDto> faculties);
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

    public IEnumerable<FacultyDto> GetFacultiesById(IEnumerable<int>? ids, bool trackChanges)
    {
        if (ids == null)
        {
            throw new IdsParameterBadException();
        }

        var faculties = _repositoryManager.Faculty.GetFacultiesByIds(ids, trackChanges);

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

    public FacultyDto CreateFaculty(FacultyCreationDto faculty)
    {
        var entity = _mapper.Map<Faculty>(faculty);
        _repositoryManager.Faculty.CreateFaculty(entity);
        _repositoryManager.Save();

        return _mapper.Map<FacultyDto>(entity);
    }
    
    public (IEnumerable<FacultyDto> faculties,string ids) CreateFaculties(IEnumerable<FacultyCreationDto> faculties)
    {
        var entities = _mapper.Map<IEnumerable<Faculty>>(faculties);
        foreach (var entity in entities)
        {
            _repositoryManager.Faculty.CreateFaculty(entity);
        }
        _repositoryManager.Save();

        var entitiesDto = _mapper.Map<IEnumerable<FacultyDto>>(entities);
        var ids = string.Join(',',entitiesDto.Select(e => e.Id));

        return (entitiesDto, ids);
    }
}