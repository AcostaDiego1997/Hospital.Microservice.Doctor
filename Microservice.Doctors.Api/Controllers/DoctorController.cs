using MediatR;
using Microservice.Doctors.Application.Commands.Request;
using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Queries.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Doctors.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize("CorsPolicy")]
    public class DoctorController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int credential)
        {
            HttpResponse_DTO<Doctor_DTO> response = new();
            try
            {
                Doctor_DTO? output = await _mediator.Send(new DoctorByCredential_Query(credential));

                response.IsSuccess = true;
                response.Message = (output != null) ? "Doctor obtenido con exito" : "La credencial ingresada no corresponde a ningun doctor";
                response.Entity = output;

                return Ok(response);
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
                List<Doctor_DTO> output = await _mediator.Send(new AllDoctors_Query());
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
                int result = await _mediator.Send(new CreateDoctor_Command(dto));

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
                int? output = await _mediator.Send(new DeleteDoctor_Command(credential));
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
