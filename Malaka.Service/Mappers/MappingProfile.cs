using AutoMapper;
using Malaka.Domain.Entities.Students;
using Malaka.Service.DTOs.Students;

namespace Malaka.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
        }
    }
}
