using Entities;

namespace Repository.TypedRepositories;

public interface IStudentRepository
{
    IEnumerable<Student> GetStudents(int facultyId,int groupId,bool trackChanges);
    Student? GetStudent(int faculty,int groupId ,int id, bool trackChanges);
    void DeleteStudent(Student student);
}

public class StudentRepository(RepositoryContext context) : RepositoryBase<Student>(context), IStudentRepository
{
    public IEnumerable<Student> GetStudents(int facultyId,int groupId,bool trackChanges) =>
        FindByCondition(stud => stud.FacultyId == facultyId && stud.GroupId == groupId,trackChanges)
            .OrderBy(stud => stud.Name)
            .ToList();

    public Student? GetStudent(int facultyId,int groupId,int id, bool trackChanges) =>
        FindByCondition(stud => stud.FacultyId == facultyId 
                                && stud.GroupId == groupId 
                                && stud.Id == id , trackChanges)
            .SingleOrDefault();

    public void DeleteStudent(Student student) => Delete(student);
}