using Microservice.Doctors.Domain.Doctor;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Doctors.Application.Interfaces.DataContext
{
    public interface IDataContext
    {
        DbSet<Doctor> Doctors { get; set; }
    }
}
