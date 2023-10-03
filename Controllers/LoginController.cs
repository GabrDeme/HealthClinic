using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;
using webapi.healthclinic.manha.ViewModel;

namespace webapi.healthclinic.manha.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuario;

        public LoginController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario user = _usuario.BuscarPorCorpo(usuario.Email!, usuario.Senha!);

                if (usuario == null)
                {
                    return NotFound("Email ou Senha invalidos!");
                }

                //Logica do token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, user.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, user.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role,user.TiposUsuario!.Titulo!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-desenvolvimento-healthclinic-webapi"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "webapi.healthclinic.manha",
                    audience: "webapi.healthclinic.manha",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: creds
                );


                // 5 parte - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }
    }
}
