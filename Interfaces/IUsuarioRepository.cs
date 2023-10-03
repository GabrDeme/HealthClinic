using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Usuario usuario);
        Usuario BuscarPorCorpo(string email, string senha);
        Usuario BuscarPorId(Guid id);
        void Atualizar(Usuario usuario, Guid id);
        List<Usuario> Listar();
        
    }
}
