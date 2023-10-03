using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IPacienteRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Paciente paciente);
        Paciente BuscarPorId(Guid id);
        List<Paciente> Listar();
    }
}
