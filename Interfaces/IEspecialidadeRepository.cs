using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Deletar(Guid id);
        void Cadastrar(EspecialidadeMedico especialidadeMedico);
        EspecialidadeMedico BuscarPorId(Guid id);
        List<EspecialidadeMedico> Listar();
    }
}
