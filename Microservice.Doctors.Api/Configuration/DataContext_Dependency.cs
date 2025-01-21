using Microservice.Doctors.Application.AppSettings.Entities;
using Microservice.Doctors.Application.AppSettings;
using Microservice.Doctors.Application.Interfaces.DataContext;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microservice.Doctors.Infrastructure.Context;

namespace Microservice.Doctors.Api.Configuration
{
    public class DataContext_Dependency
    {
        public DataContext_Dependency(IServiceCollection services, AppSettings settings)
        {
            string conn = AppSettings_Helper.GetConnectionString(settings.Environment);


            services.AddDbContext<DataContext>(options => options.UseSqlServer(conn)
             .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));

            services.AddScoped<IDbContextTransaction>(sp =>
            {
                var dataContext = sp.GetRequiredService<DataContext>();
                return dataContext.Database.BeginTransaction();
            });

            services.AddScoped<IDataContext, DataContext>();
        }
    }
}
