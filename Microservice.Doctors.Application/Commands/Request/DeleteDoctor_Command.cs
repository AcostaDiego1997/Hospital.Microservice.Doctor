using MediatR;

namespace Microservice.Doctors.Application.Commands.Request
{
    public class DeleteDoctor_Command : IRequest<int?>
    {
        public int Credential { get; set; }
        public DeleteDoctor_Command() { }
        public DeleteDoctor_Command(int credential)
        {
            Credential = credential;
        }
    }
}
