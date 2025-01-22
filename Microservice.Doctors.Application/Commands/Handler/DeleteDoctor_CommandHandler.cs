using AutoMapper;
using MediatR;
using Microservice.Doctors.Application.Commands.Request;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Doctors.Application.Commands.Handler
{
    public class DeleteDoctor_CommandHandler : IRequestHandler<DeleteDoctor_Command, int?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDoctor_CommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> Handle(DeleteDoctor_Command request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                int? output = _unitOfWork.Doctor_Repository.Delete(request.Credential);
                _unitOfWork.SaveChanges();
                await _unitOfWork.CommitTransactionAsync();

                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
