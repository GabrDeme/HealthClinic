using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;
        public MedicoRepository() 
        {
            _healthContext = new HealthContext();
        }

        public Medico BuscarPorId(Guid id)
        {
            return _healthContext.Medico.FirstOrDefault(x => x.IdMedico == id)!;
        }

        public void Cadastrar(Medico medico)
        {
            _healthContext.Medico.Add(medico);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscado = _healthContext.Medico.Find(id)!;

            _healthContext.Medico.Remove(medicoBuscado);
            _healthContext.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return _healthContext.Medico.ToList();
        }
    }
}
