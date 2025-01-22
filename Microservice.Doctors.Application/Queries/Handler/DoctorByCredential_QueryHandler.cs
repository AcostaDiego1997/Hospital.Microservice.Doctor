using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Application.Queries.Request;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Queries.Handler
{
    public class DoctorByCredential_QueryHandler : IRequestHandler<DoctorByCredential_Query, Doctor_DTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorByCredential_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Doctor_DTO> Handle(DoctorByCredential_Query request, CancellationToken cancellationToken)
        {
            try
            {
                Doctor doctor = _unitOfWork.Doctor_Repository.GetByCredential(request.Credential) ?? throw new ArgumentException($"No existe un medico con credencial '{request.Credential}'");

                Doctor_DTO output = _mapper.Map<Doctor_DTO>(doctor);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
