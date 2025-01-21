using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Doctors.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase 
    {
        private readonly IDoctor_Service _service;

        public DoctorController(IDoctor_Service doctorService)
        {
            _service = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int credential)
        {
            try
            {
                Doctor_DTO? output = _service.GetByCredential(credential);
                return Ok(new
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Doctor obtenido con exito" : "La credencial ingresada no corresponde a ningun doctor",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Doctor_DTO> output = _service.GetAll();
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Doctores obtenidos con exito",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Doctor_DTO dto)
        {
            try
            {
                _service.Post(dto);
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Doctor insertado con exito",
                    Entity = dto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int credential)
        {
            try
            {
                int? output = _service.Delete(dni);
                return Ok(new
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Doctor eliminado exitosamente" : "La credencial ingresada no corresponde a ningun doctor",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
    }
}
