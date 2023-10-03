using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IComentarioRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Comentario comentario);
        void Atualizar(Guid id, Comentario comentario);
        Comentario BuscarPorId(Guid id);
        List<Comentario> Listar();
    }
}
