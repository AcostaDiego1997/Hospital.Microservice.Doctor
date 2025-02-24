﻿using AutoMapper;
using Microservice.Doctors.Application.Commands.Request;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Automapper
{
    public class Doctor_Mapper : Profile
    {
        public Doctor_Mapper() {
            CreateMap<GetDoctor_DTO, Doctor>()
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
                        dest.SetPhone(src.Phone);
                    });

            CreateMap<Doctor, GetDoctor_DTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value));


            CreateMap<List<Doctor>, List<GetDoctor_DTO>>()
                .ConvertUsing((src, dest, context) =>
                {
                    dest = src.Select(dto => context.Mapper.Map<GetDoctor_DTO>(dto)).ToList();

                    return dest;
                });

            CreateMap<CreateDoctor_Command, Doctor>()
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

            CreateMap<Doctor, CreateDoctor_Command>()
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value));


            CreateMap<List<Doctor>, List<CreateDoctor_Command>>()
                .ConvertUsing((src, dest, context) =>
                {
                    dest = src.Select(dto => context.Mapper.Map<CreateDoctor_Command>(dto)).ToList();

                    return dest;
                });
        }
    }
}
