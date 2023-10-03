using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class EspecialidadeMedicoRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthContext;
        public EspecialidadeMedicoRepository()
        {
            _healthContext = new HealthContext();
        }

        public EspecialidadeMedico BuscarPorId(Guid id)
        {
            return _healthContext.EspecialidadeMedico.FirstOrDefault(x => x.IdEspecialidade == id)!;
        }

        public void Cadastrar(EspecialidadeMedico especialidadeMedico)
        {
            _healthContext.EspecialidadeMedico.Add(especialidadeMedico);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            EspecialidadeMedico especialidadeMedico = _healthContext.EspecialidadeMedico.Find(id)!;

            _healthContext.EspecialidadeMedico.Remove(especialidadeMedico);
            _healthContext.SaveChanges();
        }

        public List<EspecialidadeMedico> Listar()
        {
            return _healthContext.EspecialidadeMedico.ToList();
        }
    }
}

