using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthContext _healthContext;
        public ComentarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Comentario comentario)
        {
            Comentario comentarioBuscado = _healthContext.Comentario.Find(id)!;

            _healthContext.Comentario.Update(comentarioBuscado);
            _healthContext.SaveChanges();
        }

        public Comentario BuscarPorId(Guid id)
        {
            return _healthContext.Comentario.FirstOrDefault(x => x.IdComentario == id)!;
        }

        public void Cadastrar(Comentario comentario)
        {
            _healthContext.Comentario.Add(comentario);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario comentarioBuscado = _healthContext.Comentario.Find(id)!;

            _healthContext.Comentario.Remove(comentarioBuscado!);
            _healthContext.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            return _healthContext.Comentario.ToList();
        }
    }
}
