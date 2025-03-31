using AutoMapper;
using Entities;
using Entities.Exceptions.NotFound;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service.TypedServices;

public interface IGroupService
{
    IEnumerable<GroupDto> GetGroups(int facultyId,bool trackChanges);
    GroupDto? GetGroup(int facultyId,int id, bool trackChange);
}

public class GroupService(IRepositoryManager repositoryManager, IMapper mapper) : IGroupService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<GroupDto> GetGroups(int facultyId, bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }

        var groups = _repositoryManager.Group.GetGroups(facultyId, trackChanges);
        var groupsDto = _mapper.Map<IEnumerable<GroupDto>>(groups);
        return groupsDto;
    }

    public GroupDto? GetGroup(int facultyId, int id, bool trackChange)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }

        var group = _repositoryManager.Group.GetGroup(facultyId, id, trackChange);
        if (group == null)
        {
            throw new GroupNotFoundException(id);
        }

        var dto = _mapper.Map<GroupDto>(group);
        return dto;
    }
}