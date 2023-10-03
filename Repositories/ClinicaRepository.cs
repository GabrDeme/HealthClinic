using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;
        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
        }
        public Clinica BuscarPorId(Guid id)
        {
            return _healthContext.Clinica.FirstOrDefault(x => x.IdClinica == id)!;
        }

        public void Cadastrar(Clinica clinica)
        {
            _healthContext.Clinica.Add(clinica);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica clinicaBuscada = _healthContext.Clinica.Find(id)!;

            _healthContext.Clinica.Remove(clinicaBuscada);
            _healthContext.SaveChanges();

        }

        public List<Clinica> Listar()
        {
            return _healthContext.Clinica.ToList();
        }
    }
}
