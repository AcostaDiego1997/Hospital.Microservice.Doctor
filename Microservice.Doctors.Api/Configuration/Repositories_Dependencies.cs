using Microservice.Doctors.Application.Interfaces.Repository;
using Microservice.Doctors.Infrastructure.Repositories;

namespace Microservice.Doctors.Api.Configuration
{
    public class Repositories_Dependencies
    {
        public Repositories_Dependencies(IServiceCollection services)
        {
            services.AddScoped<IDoctor_Repository, Doctor_Repository>();
        }
    }
}
