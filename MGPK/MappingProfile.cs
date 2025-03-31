using AutoMapper;
using Entities;
using Shared.DTO;

namespace MGPK;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Faculty, FacultyDto>();
        CreateMap<Group, GroupDto>()
            .ForMember(dto => dto.FacultyName, opt => 
            opt.MapFrom(group => group.Faculty.Name) );
        
        CreateMap<Student,StudentDto>()
            .ForMember(dto => dto.GroupName,opt =>
            opt.MapFrom(student => student.Group.Name))
            .ForMember(dto => dto.FacultyName, opt => 
                opt.MapFrom(student => student.Group.Faculty.Name));
    }
}