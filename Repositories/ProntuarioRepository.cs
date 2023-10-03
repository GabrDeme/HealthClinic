using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthContext _healthContext;
        public ProntuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            Prontuario prontuarioBuscado = _healthContext.Prontuario.Find(id)!;

            _healthContext.Prontuario.Update(prontuarioBuscado);
            _healthContext.SaveChanges();
        }

        public Prontuario BuscarPorId(Guid id)
        {
            return _healthContext.Prontuario.FirstOrDefault(x => x.IdProntuario == id)!;
        }

        public void Cadastrar(Prontuario prontuario)
        {
            _healthContext.Prontuario.Add(prontuario);
        }

        public void Deletar(Guid id)
        {
            Prontuario prontuarioBuscado = _healthContext.Prontuario.Find(id)!;

            _healthContext.Prontuario.Remove(prontuarioBuscado);
            _healthContext.SaveChanges();
        }

        public List<Prontuario> Listar()
        {
            return _healthContext.Prontuario.ToList();
        }
    }
}
