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
    public class DoctorController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpResponse_DTO<GetDoctor_DTO> response = new();
            try
            {
                GetDoctor_DTO? output = await _mediator.Send(new DoctorByCredential_Query(id));

                response.IsSuccess = true;
                response.Message = (output != null) ? "Doctor obtenido con exito" : "La credencial ingresada no corresponde a ningun doctor";
                response.Entity = output;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<GetDoctor_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = new GetDoctor_DTO()
                });
            }
        }
        [HttpGet("summaries")]
        public async Task<IActionResult> GetSummary([FromQuery] List<int> ids)
        {
            try
            {
                List<DoctorSummary_DTO>? output = await _mediator.Send(new DoctorSummary_Query(ids));

                return Ok(new HttpResponse_DTO<List<DoctorSummary_DTO>>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Doctor obtenido con exito" : "La credencial ingresada no corresponde a ningun doctor",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<List<DoctorSummary_DTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = []
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<GetDoctor_DTO> output = await _mediator.Send(new AllDoctors_Query());

                return Ok(new HttpResponse_DTO<List<GetDoctor_DTO>>
                {
                    IsSuccess = true,
                    Message = "Doctores obtenidos con exito",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<List<GetDoctor_DTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity= []
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDoctor_DTO dto)
        {
            try
            {
                int result = await _mediator.Send(new CreateDoctor_Command(dto));

                return Ok(new HttpResponse_DTO<PostDoctor_DTO>
                {
                    IsSuccess = true,
                    Message = "Doctor insertado con exito",
                    Entity = dto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<PostDoctor_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = dto
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int credential)
        {
            try
            {
                int? output = await _mediator.Send(new DeleteDoctor_Command(credential));
                return Ok(new HttpResponse_DTO<int?>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Doctor eliminado exitosamente" : "La credencial ingresada no corresponde a ningun doctor",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<int>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = credential
                });
            }
        }
    }
}
