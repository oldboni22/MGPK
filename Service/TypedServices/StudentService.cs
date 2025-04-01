using AutoMapper;
using Entities;
using Entities.Exceptions.NotFound;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service.TypedServices;

public interface IStudentService
{
    IEnumerable<StudentDto> GetStudents(int facultyId,int groupId,bool trackChanges);
    StudentDto? GetStudent(int facultyId,int groupId,int id, bool trackChanges);
    void DeleteStudentForGroup(int facultyId,int groupId, int id,bool trackChanges);
}

public class StudentService (IRepositoryManager repositoryManager, IMapper mapper) : IStudentService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
    public IEnumerable<StudentDto> GetStudents(int facultyId,int groupId,bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }
        
        var group = _repositoryManager.Group.GetGroup(facultyId,groupId, false);
        if (group == null)
        {
            throw new GroupNotFoundException(groupId);
        }
        
        var students = _repositoryManager.Student.GetStudents(facultyId,groupId,trackChanges);

        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
        return studentsDto;
    }

    public StudentDto? GetStudent(int facultyId,int groupId,int id, bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }
        
        var group = _repositoryManager.Group.GetGroup(facultyId,groupId, false);
        if (group == null)
        {
            throw new GroupNotFoundException(groupId);
        }
        
        var student = _repositoryManager.Student.GetStudent(facultyId,groupId,id, trackChanges);
        if (student == null)
        {
            throw new StudentNotFoundException(id);
        }
        
        var dto = _mapper.Map<StudentDto>(student);
        return dto;
    }

    public void DeleteStudentForGroup(int facultyId,int groupId, int id, bool trackChanges)
    {
        var faculty = _repositoryManager.Faculty.GetFaculty(facultyId, false);
        if (faculty == null)
        {
            throw new FacultyNotFoundException(facultyId);
        }
        
        var group = _repositoryManager.Group.GetGroup(facultyId,groupId, false);
        if (group == null)
        {
            throw new GroupNotFoundException(groupId);
        }

        var student = _repositoryManager.Student.GetStudent(facultyId,groupId,id, trackChanges);
        if (student == null)
        {
            throw new StudentNotFoundException(id);
        }
        
        _repositoryManager.Student.DeleteStudent(student);
        _repositoryManager.Save();
    }
}