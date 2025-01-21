using Microservice.Doctors.Application.Automapper;

namespace Microservice.Doctors.Api.Configuration
{
    public class AutoMapper_Config
    {
        public AutoMapper_Config(IServiceCollection services)
        {
            services.AddAutoMapper(prf =>
            {
                prf.AddProfile<Doctor_Mapper>();
            });
        }
    }
}
