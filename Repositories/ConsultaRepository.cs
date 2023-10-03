using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Contexts;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;
        public ConsultaRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Consulta consulta)
        {   
            Consulta consultaBuscado = _healthContext.Consulta.Find(id)!;
            
            if (consultaBuscado != null)
            {
                consultaBuscado.DataAgentamento = consulta.DataAgentamento;
                consultaBuscado.IdPaciente = consulta.IdPaciente;
                consultaBuscado.IdMedico = consulta.IdMedico;
                consultaBuscado.IdDescricao = consulta.IdDescricao;

            }
            _healthContext.Consulta.Update(consultaBuscado!);
            _healthContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            return _healthContext.Consulta.FirstOrDefault(x => x.IdConsulta == id)!;
        }

        public void Cadastrar(Consulta consulta)
        {
            _healthContext.Consulta.Add(consulta);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;

            _healthContext.Consulta.Remove(consultaBuscada);
            _healthContext.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return _healthContext.Consulta.ToList();
        }

        public List<Consulta> ListarMedico(Guid id)
        {
            //Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;
            //if (consultaBuscada.IdMedico == id)
            //{
            //    return _healthContext.Consulta.ToList();
            //}
            //return null!;

            return _healthContext.Consulta
                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataAgentamento = c.DataAgentamento,

                    IdMedico = c.IdMedico,

                    Medico = new Medico
                    {
                        IdMedico = c.IdMedico,
                        EspecialidadeMedico = c.Medico!.EspecialidadeMedico
                    },

                    IdPaciente = c.IdPaciente,

                    Paciente = new Paciente
                    {
                        IdPaciente = c.IdPaciente,
                        CPF = c.Paciente!.CPF
                    },

                    IdDescricao = c.IdDescricao,

                    Descricao = new Descricao
                    {
                        IdDescricao = c.IdDescricao,
                        DescricaoConsulta = c.Descricao!.DescricaoConsulta
                    }
                }).Where(c => c.IdMedico == id).ToList();
        }   
        public List<Consulta> ListarPaciente(Guid id)
        {
            //Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;
            //if (consultaBuscada.IdPaciente == id)
            //{
            //    return _healthContext.Consulta.ToList();
            //}
            //return null!;

            return _healthContext.Consulta
                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataAgentamento = c.DataAgentamento,

                    IdMedico = c.IdMedico,

                    Medico = new Medico
                    {
                        IdMedico = c.IdMedico,
                        EspecialidadeMedico = c.Medico!.EspecialidadeMedico
                    },

                    IdPaciente = c.IdPaciente,

                    Paciente = new Paciente
                    {
                        IdPaciente = c.IdPaciente,
                        CPF = c.Paciente!.CPF
                    },

                    IdDescricao = c.IdDescricao,

                    Descricao = new Descricao
                    {
                        IdDescricao = c.IdDescricao,
                        DescricaoConsulta = c.Descricao!.DescricaoConsulta
                    }
                }).Where(c => c.IdPaciente == id).ToList();
        }
    }
}
