using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;
        public PacienteRepository()
        {
            _healthContext = new HealthContext();
        }

        public Paciente BuscarPorId(Guid id)
        {
            return _healthContext.Paciente.FirstOrDefault(x => x.IdPaciente == id)!;
        }

        public void Cadastrar(Paciente paciente)
        {
            _healthContext.Paciente.Add(paciente);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = _healthContext.Paciente.Find(id)!;

            _healthContext.Paciente.Remove(pacienteBuscado);
            _healthContext.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return _healthContext.Paciente.ToList();
        }
    }
}
