using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Application.Queries.Request;
using Microservice.Doctors.Domain.Doctor;
using System.Threading.Tasks.Dataflow;

namespace Microservice.Doctors.Application.Queries.Handler
{
    public class DoctorSummary_QueryHandler : IRequestHandler<DoctorSummary_Query, List<DoctorSummary_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorSummary_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DoctorSummary_DTO>> Handle(DoctorSummary_Query request, CancellationToken cancellationToken)
        {
            try
            {
                List<Doctor> doc = _unitOfWork.Doctor_Repository.GetById(request.Ids) ?? throw new Exception($"No existe un doctor con id {string.Join(",", request.Ids)}");
               
                List<DoctorSummary_DTO> output = _mapper.Map<List<DoctorSummary_DTO>>(doc);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
