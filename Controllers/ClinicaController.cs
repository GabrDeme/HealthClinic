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

    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinica;

        public ClinicaController()
        {
            _clinica = new ClinicaRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Clinica clinica)
        {
            try 
            {
                _clinica.Cadastrar(clinica);
                return StatusCode(201);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _clinica.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Administrador,Médico,Paciente")]
        public IActionResult Get() 
        {
            try
            {                
                return Ok(_clinica.Listar());
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Médico,Paciente")]
        public IActionResult Get(Guid id) 
        {
            try
            {
                _clinica.BuscarPorId(id);
                return Ok();
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
