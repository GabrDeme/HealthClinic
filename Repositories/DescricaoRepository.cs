using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class DescricaoRepository : IDescricaoRepository
    {
        private readonly HealthContext _healthContext;
        public DescricaoRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Cadastrar(Descricao descricao)
        {
            _healthContext.Descricao.Add(descricao);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Descricao descricaoBuscada = _healthContext.Descricao.Find(id)!;

            _healthContext.Descricao.Remove(descricaoBuscada!);
            _healthContext.SaveChanges();
        }
    }
}
