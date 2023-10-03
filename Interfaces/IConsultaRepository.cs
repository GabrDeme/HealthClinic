using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Consulta consulta);
        void Atualizar(Guid id, Consulta consulta);
        Consulta BuscarPorId(Guid id);
        List<Consulta> Listar();
        List<Consulta> ListarMedico(Guid id);
        List<Consulta> ListarPaciente(Guid id);
    }
}