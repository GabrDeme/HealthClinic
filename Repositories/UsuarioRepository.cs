using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Utils;

namespace webapi.healthclinic.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Usuario usuario, Guid id)
        {
            Usuario usuarioBuscado = _healthContext.Usuario.Find(id)!;
            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTiposUsuario = usuario.IdTiposUsuario;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
            }
            _healthContext.Usuario.Update(usuarioBuscado!);
            _healthContext.SaveChanges();
        }

        public Usuario BuscarPorCorpo(string email, string senha)
        {
            Usuario usuario = _healthContext.Usuario
                 .Select(u => new Usuario
                 {
                     IdUsuario = u.IdUsuario,
                     Nome = u.Nome,
                     Email = u.Email,
                     Senha = u.Senha,
                     TiposUsuario = new TiposUsuario
                     {
                         IdTiposUsuario = u.IdTiposUsuario,
                         Titulo = u.TiposUsuario!.Titulo
                     }
                 }).FirstOrDefault(u => u.Email == email)!;

            if (usuario != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuario.Senha!);

                if (confere)
                {
                    return usuario;
                }
            }
            return null!;
        }


        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuario = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        TiposUsuario = new TiposUsuario
                        {
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuario != null)
                {
                    return usuario;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healthContext.Usuario.Add(usuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.Find(id)!;

                _healthContext.Usuario.Remove(usuarioBuscado);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Listar()
        {
            return _healthContext.Usuario.ToList();
        }
    }
}
