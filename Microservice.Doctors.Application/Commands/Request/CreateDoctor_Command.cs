using MediatR;
using Microservice.Doctors.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Doctors.Application.Commands.Request
{
    public class CreateDoctor_Command :IRequest<int>
    {
        public int Credential { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public CreateDoctor_Command() { }
        public CreateDoctor_Command(PostDoctor_DTO dto) 
        { 
            Credential = dto.Credential;
            Name = dto.Name;
            LastName = dto.LastName;
            Specialty = dto.Specialty;
            Email = dto.Email;
            Password = dto.Password;
            Phone = dto.Phone;
        }
    }
}
