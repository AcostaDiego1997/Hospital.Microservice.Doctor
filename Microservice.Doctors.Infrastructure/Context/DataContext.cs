using Microservice.Doctors.Application.Interfaces.DataContext;
using Microservice.Doctors.Domain.Doctor;
using Microservice.Doctors.Infrastructure.TableConfig;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Doctors.Infrastructure.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Doctor_TableConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
