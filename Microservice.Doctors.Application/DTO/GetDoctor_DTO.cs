using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Doctors.Application.DTO
{
    public class GetDoctor_DTO
    {
        public int Id { get; set; } 
        [Required]
        public int Credential { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Specialty { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!; 
        [Required]
        public string Phone { get; set; } = null!;

    }
}
