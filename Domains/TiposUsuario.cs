using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(TiposUsuario))]
    [Index(nameof(Titulo), IsUnique = true)]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTiposUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo usuário obrigatório")]
        public string? Titulo { get; set; }
    }
}
