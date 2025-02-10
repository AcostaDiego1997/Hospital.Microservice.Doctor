using AutoMapper;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Automapper
{
    public class DoctorSummary_Mapper : Profile
    {
        public DoctorSummary_Mapper()
        {
            CreateMap<Doctor, DoctorSummary_DTO>() 
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
