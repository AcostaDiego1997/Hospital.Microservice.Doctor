using MediatR;
using Microservice.Doctors.Application.DTO;

namespace Microservice.Doctors.Application.Queries.Request
{
    public class DoctorSummary_Query : IRequest<DoctorSummary_DTO>
    {
        public int Credential {  get; set; }

        public DoctorSummary_Query(){ }
        public DoctorSummary_Query(int credential) { Credential = credential; }
    }
}
