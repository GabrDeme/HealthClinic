using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Medico medico);
        Medico BuscarPorId(Guid id);
        List<Medico> Listar();
    }
}
