using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IStudentService
{
    
}

public class StudentService (IRepositoryManager repositoryManager, IMapper mapper, ILogger<StudentService> logger) : IStudentService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<StudentService> _logger = logger;
}