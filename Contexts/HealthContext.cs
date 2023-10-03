using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Contexts
{
    public class HealthContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<EspecialidadeMedico> EspecialidadeMedico { get; set; }
        public DbSet<Descricao> Descricao { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Comentario> Comentario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE21-S15; Database = webapi.healthclinic.manha; User Id= Sa; Pwd= Senai@134; TrustServerCertificate= True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}


