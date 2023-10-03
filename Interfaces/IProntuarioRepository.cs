using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IProntuarioRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Prontuario prontuario);
        void Atualizar(Guid id, Prontuario prontuario);
        Prontuario BuscarPorId(Guid id);
        List<Prontuario> Listar();
    }
}
