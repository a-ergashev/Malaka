using AutoMapper;
using Malaka.Domain.Entities.Courses;
using Malaka.Domain.Entities.Instructors;
using Malaka.Domain.Entities.Students;
using Malaka.Service.DTOs.Courses;
using Malaka.Service.DTOs.Instructors;
using Malaka.Service.DTOs.Students;

namespace Malaka.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
            CreateMap<InstructorForCreationDto, Instructor>().ReverseMap();
            CreateMap<CourseForCreationDto, Course>().ReverseMap();
        }
    }
}
