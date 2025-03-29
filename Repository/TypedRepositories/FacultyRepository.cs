using Entities;

namespace Repository.TypedRepositories;

public interface IFacultyRepository
{
    IEnumerable<Faculty> FindAll(bool trackChanges);
}

public class FacultyRepository(RepositoryContext context) : RepositoryBase<Faculty>(context), IFacultyRepository
{
    public IEnumerable<Faculty> FindAll(bool trackChanges) => 
        FindAll(trackChanges)
            .OrderBy(_ => _.Name)
            .ToList();



}