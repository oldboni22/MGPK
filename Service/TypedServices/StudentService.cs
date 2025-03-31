using AutoMapper;
using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using Shared.DTO;

namespace Service.TypedServices;

public interface IStudentService
{
    IEnumerable<StudentDto> GetStudents(bool trackChanges);
    StudentDto? GetStudent(int id, bool trackChanges);
}

public class StudentService (IRepositoryManager repositoryManager, IMapper mapper) : IStudentService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;
    public IEnumerable<StudentDto> GetStudents(bool trackChanges)
    {
        var students = _repositoryManager.Student.GetStudents(trackChanges);

        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
        return studentsDto;
    }

    public StudentDto? GetStudent(int id, bool trackChanges)
    {
        var student = _repositoryManager.Student.GetStudent(id, trackChanges);
        if (student != null)
        {
            var dto = _mapper.Map<StudentDto>(student);
            return dto;
        }
        
        return null;
    }
}