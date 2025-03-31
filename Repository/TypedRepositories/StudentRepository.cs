using Entities;

namespace Repository.TypedRepositories;

public interface IStudentRepository
{
    IEnumerable<Student> GetStudents(bool trackChanges);
    Student? GetStudent(int id, bool trackChanges);
}

public class StudentRepository(RepositoryContext context) : RepositoryBase<Student>(context), IStudentRepository
{
    public IEnumerable<Student> GetStudents(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(stud => stud.Name)
            .ToList();

    public Student? GetStudent(int id, bool trackChanges) =>
        FindByCondition(stud => stud.Id == id, trackChanges)
            .SingleOrDefault();

}