using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data de agendamento obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? DataAgentamento { get; set; }

        //referência
        public Guid IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        public Guid IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        public Guid IdDescricao { get; set; }
        [ForeignKey(nameof(IdDescricao))]
        public Descricao? Descricao { get; set; }
    }
}
