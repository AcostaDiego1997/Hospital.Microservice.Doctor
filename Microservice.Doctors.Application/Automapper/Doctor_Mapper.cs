using AutoMapper;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Automapper
{
    public class Doctor_Mapper : Profile
    {
        public Doctor_Mapper() {
            CreateMap<Doctor_DTO, Doctor>()
                    .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                    .ForMember(dest => dest.Name, opt => opt.Ignore())
                    .ForMember(dest => dest.LastName, opt => opt.Ignore())
                    .ForMember(dest => dest.Specialty, opt => opt.Ignore())
                    .ForMember(dest => dest.Email, opt => opt.Ignore())
                    .ForMember(dest => dest.Password, opt => opt.Ignore())
                    .ForMember(dest => dest.Phone, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        dest.SetCredential(src.Credential);
                        dest.SetName(src.Name);
                        dest.SetLastName(src.LastName);
                        dest.SetStatus(true);
                        dest.SetSpecialty(src.Specialty);
                        dest.SetEmail(src.Email);
                        dest.SetPassword(src.Password);
                        dest.SetPhone(src.Phone);
                    });

            CreateMap<Doctor, Doctor_DTO>()
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value));


            CreateMap<List<Doctor>, List<Doctor_DTO>>()
                .ConvertUsing((src, dest, context) =>
                {
                    dest = src.Select(dto => context.Mapper.Map<Doctor_DTO>(dto)).ToList();

                    return dest;
                });
        }
    }
}
