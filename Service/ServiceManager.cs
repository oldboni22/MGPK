using Microsoft.Extensions.Logging;
using Repository;

namespace Service;

public interface IServiceManager
{
    IFacultyService Faculty { get; }
    IGroupService Group { get; }
    IStudentService Student { get; }
}

public class ServiceManager(IRepositoryManager repositoryManager,ILogger logger) : IServiceManager
{
    private readonly Lazy<IFacultyService> _faculty = new Lazy<IFacultyService>(() => new FacultyService(repositoryManager,logger));
    private readonly Lazy<IGroupService> _group = new Lazy<IGroupService>(() => new GroupService(repositoryManager,logger));
    private readonly Lazy<IStudentService> _student = new Lazy<IStudentService>(()=> new StudentService(repositoryManager,logger));

    public IFacultyService Faculty => _faculty.Value;
    public IGroupService Group => _group.Value;
    public IStudentService Student => _student.Value;
}