using MediatR;
using Microservice.Doctors.Application.DTO;

namespace Microservice.Doctors.Application.Queries.Request
{
    public class DoctorSummary_Query : IRequest<List<DoctorSummary_DTO>>
    {
        public List<int> Ids {  get; set; }

        public DoctorSummary_Query(){ }
        public DoctorSummary_Query(List<int> ids) { Ids = ids; }
    }
}
