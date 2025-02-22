using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Application.Queries.Request;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Queries.Handler
{
    public class DoctorById_QueryHandler : IRequestHandler<DoctorByCredential_Query, GetDoctor_DTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorById_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDoctor_DTO> Handle(DoctorByCredential_Query request, CancellationToken cancellationToken)
        {
            try
            {
                Doctor doctor = _unitOfWork.Doctor_Repository.GetById(request.Id) ?? throw new ArgumentException($"No existe un medico con id '{request.Id}'");

                GetDoctor_DTO output = _mapper.Map<GetDoctor_DTO>(doctor);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
