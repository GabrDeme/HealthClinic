using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthContext _healthContext;
        public TiposUsuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, TiposUsuario tiposUsuario)
        {
            TiposUsuario tUsuarioBuscado = _healthContext.TiposUsuario.Find(id)!;

            if (tUsuarioBuscado != null)
            {
                tUsuarioBuscado.Titulo = tiposUsuario.Titulo;
            }
            _healthContext.TiposUsuario.Update(tUsuarioBuscado!);
            _healthContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _healthContext.TiposUsuario.FirstOrDefault(x => x.IdTiposUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _healthContext.TiposUsuario.Add(tipoUsuario);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tUsuarioBuscado = _healthContext.TiposUsuario.Find(id)!;

            _healthContext.TiposUsuario.Remove(tUsuarioBuscado);
            _healthContext.SaveChanges();
        }

        List<TiposUsuario> ITiposUsuarioRepository.Listar()
        {
            return _healthContext.TiposUsuario.ToList();
        }
    }
}
