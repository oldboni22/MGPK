using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service.TypedServices;

public interface IGroupService
{
    
}

public class GroupService (IRepositoryManager repositoryManager, IMapper mapper) : IGroupService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
}