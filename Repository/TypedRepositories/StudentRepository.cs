using Entities;

namespace Repository.TypedRepositories;

public interface IStudentRepository
{
    
}

public class StudentRepository(RepositoryContext context) : RepositoryBase<Student>(context), IStudentRepository
{
    
}