using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Interfaces.Repository
{
    public interface IDoctor_Repository
    {
        void Add(Doctor doctor);
        Doctor? GetByCredential(int credential);
        Doctor? GetById(int id);
        List<Doctor>? GetById(List<int> ids);
        List<Doctor> GetAll();
        int? Delete(int dni);
        int UniqueDoctorValidation(GetDoctor_DTO dto);
    }
}
