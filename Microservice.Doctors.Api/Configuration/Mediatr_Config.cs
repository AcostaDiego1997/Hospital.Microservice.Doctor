using Microservice.Doctors.Application.Commands.Handler;

namespace Microservice.Doctors.Api.Configuration
{
    public class Mediatr_Config
    {
        public Mediatr_Config(IServiceCollection services) 
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(CreateDoctor_CommandHandler));
            });
        }
    }
}
