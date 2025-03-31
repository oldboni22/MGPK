using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service.TypedServices;

public interface IStudentService
{
    
}

public class StudentService (IRepositoryManager repositoryManager, IMapper mapper) : IStudentService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
}