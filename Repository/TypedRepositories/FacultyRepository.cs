using Entities;

namespace Repository.TypedRepositories;

public interface IFacultyRepository
{
    IEnumerable<Faculty> GetAllFaculties(bool trackChanges);
    IEnumerable<Faculty> GetFacultiesByIds(IEnumerable<int> ids, bool trackChanges);
    Faculty? GetFaculty(int id, bool trackChanges);
    void CreateFaculty(Faculty faculty);
    void DeleteFaculty(Faculty faculty);
}

public class FacultyRepository(RepositoryContext context) : RepositoryBase<Faculty>(context), IFacultyRepository
{
    public IEnumerable<Faculty> GetAllFaculties(bool trackChanges) => 
        FindAll(trackChanges)
            .OrderBy(faculty => faculty.Name)
            .ToList();

    public IEnumerable<Faculty> GetFacultiesByIds(IEnumerable<int> ids, bool trackChanges) =>
        FindByCondition(faculty => ids.Contains(faculty.Id), trackChanges)
            .OrderBy(faculty => faculty.Name)
            .ToList();
    

    public Faculty? GetFaculty(int id, bool trackChanges) =>
        FindByCondition(f => f.Id == id,trackChanges)
            .SingleOrDefault();
    
    public void CreateFaculty(Faculty faculty)
    {
        Create(faculty);
    }

    public void DeleteFaculty(Faculty faculty) => Delete(faculty);
}