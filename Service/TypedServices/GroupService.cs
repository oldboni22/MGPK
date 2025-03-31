using AutoMapper;
using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service.TypedServices;

public interface IGroupService
{
    IEnumerable<GroupDto> GetGroups(bool trackChanges);
    GroupDto? GetGroup(int id, bool trackChange);
}

public class GroupService (IRepositoryManager repositoryManager, IMapper mapper) : IGroupService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
    public IEnumerable<GroupDto> GetGroups(bool trackChanges)
    {
        var groups = _repositoryManager.Group.GetGroups(trackChanges);
        
        var groupsDto = _mapper.Map<IEnumerable<GroupDto>>(groups);
        return groupsDto;
    }

    public GroupDto? GetGroup(int id, bool trackChange)
    {
        var group = _repositoryManager.Group.GetGroup(id, trackChange);
        if (group != null)
        {
            var dto = _mapper.Map<GroupDto>(group);
            return dto;
        }

        return null;
    }
}