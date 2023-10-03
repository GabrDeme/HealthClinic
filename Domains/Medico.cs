using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(8)")]
        [Required(ErrorMessage = "CRM obrigatória")]
        public string? CRM { get; set; }

        //referência
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        public Guid IdEspecialidade { get; set; }
        [ForeignKey(nameof(IdEspecialidade))]
        public EspecialidadeMedico? EspecialidadeMedico { get; set; }

        public Guid IdClinica { get; set; }
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
