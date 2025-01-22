using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.Commands.Request;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Domain.Doctor;

namespace Microservice.Doctors.Application.Commands.Handler
{
    public class CreateDoctor_CommandHandler : IRequestHandler<CreateDoctor_Command, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDoctor_CommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<int> Handle(CreateDoctor_Command request, CancellationToken cancellationToken)
        {
            try
            {
                Doctor doctor = _mapper.Map<Doctor>(request);
                _unitOfWork.BeginTransaction();
                _unitOfWork.Doctor_Repository.Add(doctor);
                int output = _unitOfWork.SaveChanges();
                await _unitOfWork.CommitTransactionAsync();

                if (output == 0)
                    throw new Exception($"El doctor '{request.LastName}' pudo ser insertado.");

                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
