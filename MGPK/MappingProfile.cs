using AutoMapper;
using Entities;
using Shared.DTO;

namespace MGPK;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Faculty, FacultyDto>();
        CreateMap<Group, GroupDto>();
        CreateMap<Student,StudentDto>();

        CreateMap<FacultyCreationDto, Faculty>();
        CreateMap<GroupCreationDto, Group>();
        CreateMap<StudentCreationDto, Student>();
    }
}