using MediatR;
using Microservice.Doctors.Application.DTO;

namespace Microservice.Doctors.Application.Queries.Request
{
    public class DoctorByCredential_Query : IRequest<Doctor_DTO>
    {
        public int Credential {  get; set; }
        public DoctorByCredential_Query(int credential) {  Credential = credential; }
    }
}
