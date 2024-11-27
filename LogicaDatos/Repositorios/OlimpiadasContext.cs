using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class OlimpiadasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Disciplina> Disciplinas{ get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participaciones> Participaciones { get; set; }




        public OlimpiadasContext(DbContextOptions options) : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = true;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atleta>()
                .HasMany(a => a._disciplinas)
                .WithMany(d => d._atletas)
                .UsingEntity<Dictionary<string, object>>(
                    "AtletaDisciplina", // Nombre de la tabla intermedia en la DB
                    j => j.HasOne<Disciplina>().WithMany().HasForeignKey("DisciplinaId"),
                    j => j.HasOne<Atleta>().WithMany().HasForeignKey("AtletaId"));
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    //string strCon = "Server=localhost; Database=Olimpiadas_2024; Integrated Security=SSPI; TrustServerCertificate=True";
        //    //optionsBuilder.UseSqlServer(strCon);
        //}
    }
}
