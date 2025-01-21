using Microservice.Doctors.Application.DTO;

namespace Microservice.Doctors.Application.Interfaces.Service
{
    public interface IDoctor_Service
    {
        Doctor_DTO? GetByCredential(int credential);
        List<Doctor_DTO> GetAll();
        Doctor_DTO? Post(Doctor_DTO dto);
        int? Delete(int credential);
    }
}
