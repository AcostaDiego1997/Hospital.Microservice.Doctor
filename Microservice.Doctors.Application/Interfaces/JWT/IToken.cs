using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Interfaces.JWT
{
    public interface IToken
    {
        string CreateToken(Doctor doctor);
        bool? ValidateToken(string token);
    }
}
