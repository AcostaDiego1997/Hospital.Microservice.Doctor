using MediatR;
using Microservice.Doctors.Application.DTO;

namespace Microservice.Doctors.Application.Queries.Request
{
    public class DoctorByCredential_Query : IRequest<GetDoctor_DTO>
    {
        public int Id {  get; set; }
        public DoctorByCredential_Query(int id) {  Id = id; }
    }
}
