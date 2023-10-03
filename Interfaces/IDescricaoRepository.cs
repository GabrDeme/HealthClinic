using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IDescricaoRepository
    {
        void Deletar(Guid id);
        void Cadastrar(Descricao descricao);
    }
}
