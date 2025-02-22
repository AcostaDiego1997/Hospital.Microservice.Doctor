using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Application.Queries.Request;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Queries.Handler
{
    public class AllDoctors_QueryHandler : IRequestHandler<AllDoctors_Query, List<GetDoctor_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllDoctors_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<GetDoctor_DTO>> Handle(AllDoctors_Query request, CancellationToken cancellationToken)
        {
            try
            {
                List<Doctor> doctors = _unitOfWork.Doctor_Repository.GetAll();
                List<GetDoctor_DTO> output = _mapper.Map<List<GetDoctor_DTO>>(doctors);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
