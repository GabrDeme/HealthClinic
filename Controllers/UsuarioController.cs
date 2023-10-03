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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuario;

        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Paciente")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuario.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Médico,Paciente")]
        public IActionResult Get(string email, string senha)
        {

            try
            {
                return Ok(_usuario.BuscarPorCorpo(email, senha));
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
                Usuario BuscarId = _usuario.BuscarPorId(id);

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
                _usuario.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Usuario usuario, Guid id)
        {
            try
            {
                 _usuario.Atualizar(usuario, id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
