using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Application.Queries.Request;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Queries.Handler
{
    public class DoctorSummary_QueryHandler : IRequestHandler<DoctorSummary_Query, DoctorSummary_DTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorSummary_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorSummary_DTO> Handle(DoctorSummary_Query request, CancellationToken cancellationToken)
        {
            try
            {
                Doctor doc = _unitOfWork.Doctor_Repository.GetByCredential(request.Credential) ?? throw new Exception($"No existe un doctor con credencial {request.Credential}");
               
                DoctorSummary_DTO output = _mapper.Map<DoctorSummary_DTO>(doc);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
