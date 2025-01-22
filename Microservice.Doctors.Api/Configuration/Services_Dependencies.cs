using Microservice.Doctors.Application.Interfaces.JWT;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Infrastructure.JWT;
using Microservice.Doctors.Infrastructure.UnitOfWork;

namespace Microservice.Doctors.Api.Configuration
{
    public class Services_Dependencies
    {
        public Services_Dependencies(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IToken, TokenManager>();
        }
    }
}
