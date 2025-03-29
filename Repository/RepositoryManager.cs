using Repository.TypedRepositories;

namespace Repository;


public interface IRepositoryManager
{
    IFacultyRepository Faculty { get; }
    IGroupRepository Group { get; }
    IStudentRepository Student { get; }
    
    
    void Save();
} 

public sealed class RepositoryManager(RepositoryContext context) : IRepositoryManager
{
    private readonly Lazy<FacultyRepository> _faculty = new(() => 
        new FacultyRepository(context));
    
    private readonly Lazy<GroupRepository> _group = new(()=> 
        new GroupRepository(context));
    
    private readonly Lazy<StudentRepository> _student = new( ()=> 
        new StudentRepository(context));


    public IFacultyRepository Faculty => _faculty.Value;
    public IGroupRepository Group => _group.Value;
    public IStudentRepository Student => _student.Value;
  
    public void Save()
    {
        context.SaveChanges();
    }

    
}