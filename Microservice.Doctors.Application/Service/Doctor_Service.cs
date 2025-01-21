using AutoMapper;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.Service;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Service
{
    public class Doctor_Service : IDoctor_Service
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Doctor_Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<Doctor_DTO> GetAll()
        {
            try
            {
                List<Doctor> doctors = _unitOfWork.Doctor_Repository.GetAll();
                List<Doctor_DTO> output = _mapper.Map<List<Doctor_DTO>>(doctors);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Doctor_DTO? GetByCredential(int credential)
        {
            try
            {
                Doctor? doctor = _unitOfWork.Doctor_Repository.GetByCredential(credential);
                if (doctor == null)
                    return null;

                Doctor_DTO output = _mapper.Map<Doctor_DTO>(doctor);
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Doctor_DTO? Post(Doctor_DTO dto)
        {
            try
            {
                ValidateUniqueDoctor(dto);

                Doctor output = _mapper.Map<Doctor>(dto);
                _unitOfWork.BeginTransaction();
                _unitOfWork.Doctor_Repository.Add(output);
                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();
                return dto;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }


        public int? Delete(int dni)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                int? doctor = _unitOfWork.Doctor_Repository.Delete(dni);

                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();

                return doctor;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }

        private void ValidateUniqueDoctor(Doctor_DTO dto)
        {
            int result = _unitOfWork.Doctor_Repository.UniqueDoctorValidation(dto);
            if (result > 0)
                throw new Exception($"Ya se encuentra dado de alta un doctor los datos solicitados.");
        }
    }
}
