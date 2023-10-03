using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data de nascimento obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "Número de telefone obrigatório")]
        public string? Telefone { get; set; }

        [Column(TypeName = "CHAR(7)")]
        [Required(ErrorMessage = "RG obrigatório")]
        public string? RG { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "CPF obrigatório")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string? Endereco { get; set; }

        //referência
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
        
    }
}
