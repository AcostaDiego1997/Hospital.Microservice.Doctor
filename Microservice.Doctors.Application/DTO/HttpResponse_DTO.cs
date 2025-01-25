using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Doctors.Application.DTO
{
    public class HttpResponse_DTO<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public T Entity { get; set; }
    }
}
