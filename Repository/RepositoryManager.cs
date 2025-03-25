using Repository.TypedRepositories;

namespace Repository;


public interface IRepositoryManager
{
    IFacultyRepository Faculty { get; }
    IGroupRepository Group { get; }
    IStudentRepository Student { get; }
    
    
    void Save();
} 

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<FacultyRepository> _faculty;
    private readonly Lazy<GroupRepository> _group;
    private readonly Lazy<StudentRepository> _student;

    private readonly RepositoryContext _context;
    
    public RepositoryManager(RepositoryContext context)
    {
        _faculty = new Lazy<FacultyRepository>(() => new FacultyRepository(context));
        _group = new Lazy<GroupRepository>(()=> new GroupRepository(context));
        _student = new Lazy<StudentRepository>( ()=> new StudentRepository(context));

        _context = context;
    }


    public IFacultyRepository Faculty => _faculty.Value;
    public IGroupRepository Group => _group.Value;
    public IStudentRepository Student => _student.Value;
  
    public void Save()
    {
        _context.SaveChanges();
    }

    
}