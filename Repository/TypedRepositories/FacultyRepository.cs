using Entities;

namespace Repository.TypedRepositories;

public interface IFacultyRepository
{
    IEnumerable<Faculty> GetAllFaculties(bool trackChanges);
    Faculty? GetFaculty(int id, bool trackChanges);
}

public class FacultyRepository(RepositoryContext context) : RepositoryBase<Faculty>(context), IFacultyRepository
{
    public IEnumerable<Faculty> GetAllFaculties(bool trackChanges) => 
        FindAll(trackChanges)
            .OrderBy(faculty => faculty.Name)
            .ToList();

    public Faculty? GetFaculty(int id, bool trackChanges) =>
        FindByCondition(f => f.Id == id,trackChanges)
            .SingleOrDefault();


}