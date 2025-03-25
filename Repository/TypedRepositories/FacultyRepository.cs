using Entities;

namespace Repository.TypedRepositories;

public interface IFacultyRepository
{
    
}

public class FacultyRepository(RepositoryContext context) : RepositoryBase<Faculty>(context), IFacultyRepository
{
}