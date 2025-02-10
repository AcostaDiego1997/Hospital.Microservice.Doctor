
namespace Microservice.Doctors.Application.DTO
{
    public class DoctorSummary_DTO
    {
        public int Id { get; set; }
        public int Credential { get; set; }
        public string FullName { get; set; } = null!;
    }
}
