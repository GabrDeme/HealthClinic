using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consulta;

        public ConsultaController()
        {
            _consulta = new ConsultaRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consulta.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Consulta BuscarId = _consulta.BuscarPorId(id);

                return Ok(BuscarId);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consulta.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consulta.Atualizar(id, consulta);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Medico")]
        [Authorize(Roles = "Administrador,Médico")]
        public IActionResult GetbyIdM(Guid id)
        {
            try
            {
                List<Consulta> ListarMedico = _consulta.ListarMedico(id);

                return Ok(ListarMedico);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("Paciente")]
        [Authorize(Roles = "Administrador,Paciente")]
        public IActionResult GetbyIdP(Guid id)
        {
            try
            {
                return Ok(_consulta.ListarPaciente(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
