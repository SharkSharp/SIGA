using ArthurFrederico.SIGA.Model;
using System.Data.Entity;

namespace ArthurFrederico.SIGA.Model
{
    class SIGAContext : DbContext
    {
        public DbSet<CidadeModel> Cidade { get; set; }

        public DbSet<UsuarioModel> Usuario { get; set; }

        public DbSet<AlunoModel> Aluno { get; set; }

        public DbSet<TutorModel> Tutor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasRequired(x => x.Cidade)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlunoModel>()
                .HasRequired(x => x.Tutor1)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlunoModel>()
                .HasRequired(x => x.Tutor2)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
