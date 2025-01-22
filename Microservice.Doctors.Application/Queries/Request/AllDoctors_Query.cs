using MediatR;
using Microservice.Doctors.Application.DTO;

namespace Microservice.Doctors.Application.Queries.Request
{
    public class AllDoctors_Query : IRequest<List<Doctor_DTO>>
    {
    }
}
