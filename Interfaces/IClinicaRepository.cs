using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IClinicaRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Clinica clinica);
        Clinica BuscarPorId(Guid id);
        List<Clinica> Listar();
    }
}
