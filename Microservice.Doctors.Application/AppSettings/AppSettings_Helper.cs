using Microservice.Doctors.Application.AppSettings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Doctors.Application.AppSettings
{
    public class AppSettings_Helper
    {
        public static string Environment { get; set; } = null!;
        public static ConnectionStrings ConnectionStrings { get; set; } = null!;
        public static Auth Auth { get; set; } = null!;

        public static string GetConnectionString(string env)
        {
            if (env == "dev")
                return ConnectionStrings.Db_Dev;
            if (env == "test")
                return ConnectionStrings.Db_Test;
            if (env == "prod")
                return ConnectionStrings.Db_Prod;

            throw new Exception($"Ocurrio un error al acceder a la base de datos. El ambiente '{Environment}' no tiene una base de datos asignada.");
        }
    }
}
