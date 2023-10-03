using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Descricao))]
    public class Descricao
    {
        [Key]
        public Guid IdDescricao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição obrigatório")]
        public string? DescricaoConsulta { get; set; }

    }
}
