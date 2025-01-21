using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Interfaces.Repository
{
    public interface IDoctor_Repository
    {
        void Add(Doctor doctor);
        Doctor? GetByCredential(int credential);
        List<Doctor> GetAll();
        int? Delete(int dni);
        int UniqueDoctorValidation(Doctor_DTO dto);
    }
}
