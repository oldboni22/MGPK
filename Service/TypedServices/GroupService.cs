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
    GroupDto? GetGroup(int facultyId,int id, bool trackChanges);
    GroupDto CreateGroupForFaculty(int facultyId, GroupCreationDto group);
    void DeleteGroupForFaculty(int facultyId, int id, bool trackChanges);
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

    public GroupDto? GetGroup(int facultyId, int id, bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }

        var group = _repositoryManager.Group.GetGroup(facultyId, id, trackChanges);
        if (group == null)
        {
            throw new GroupNotFoundException(id);
        }

        var dto = _mapper.Map<GroupDto>(group);
        return dto;
    }

    public GroupDto CreateGroupForFaculty(int facultyId, GroupCreationDto group)
    {
        var entity = _mapper.Map<Group>(group);

        _repositoryManager.Group.CreateGroupForFaculty(facultyId, entity);
        _repositoryManager.Save();

        return _mapper.Map<GroupDto>(entity);
    }

    public void DeleteGroupForFaculty(int facultyId, int id, bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }

        var group = _repositoryManager.Group.GetGroup(facultyId, id, trackChanges);
        if (group == null)
        {
            throw new GroupNotFoundException(id);
        }
        
        _repositoryManager.Group.DeleteGroup(group);
        _repositoryManager.Save();
    }
}