using System.Runtime.Versioning;
using AutoMapper;
using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using Service.TypedServices;

namespace Service;


public interface IServiceManager
{
    IFacultyService Faculty { get; }
    IGroupService Group { get; }
    IStudentService Student { get; }
}

public class ServiceManager(IRepositoryManager repositoryManager,IMapper mapper) : IServiceManager
{
    private readonly Lazy<IFacultyService> _faculty = new Lazy<IFacultyService>(() =>
        new FacultyService(repositoryManager,mapper));
    
    private readonly Lazy<IGroupService> _group = new Lazy<IGroupService>(() => 
        new GroupService(repositoryManager,mapper));
    
    private readonly Lazy<IStudentService> _student = new Lazy<IStudentService>(()=> 
        new StudentService(repositoryManager,mapper));

    public IFacultyService Faculty => _faculty.Value;
    public IGroupService Group => _group.Value;
    public IStudentService Student => _student.Value;
}