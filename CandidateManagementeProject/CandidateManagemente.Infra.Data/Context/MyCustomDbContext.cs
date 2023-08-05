using CandidateManagemente.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagemente.Infra.Data.Context
{
    public class MyCustomDbContext : DbContext
    {
        public MyCustomDbContext(DbContextOptions<MyCustomDbContext> options) : base(options)
        {
        }

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<Experiences> Experiences { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Credentials> Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.ToTable("Candidates");
                entity.HasKey(p => p.IdCandidate);
                entity.HasAlternateKey(p => p.Email);
            });

            modelBuilder.Entity<Experiences>(entity =>
            {
                entity.HasKey(p => p.IdCandidateExperience);
                entity.HasOne(p => p.Candidates).WithMany().HasForeignKey(p => p.IdCandidate);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.IdUser);
                entity.HasOne(u => u.Credentials)
                      .WithOne(c => c.User)
                      .HasForeignKey<Credentials>(c => c.UserId);

            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
				"Data Source=Caio_Coutinho;Initial Catalog=DB_CandidateManagemente;Integrated Security=True; MultipleActiveResultSets=False; TrustServerCertificate=true;");
            }
        }
    }
}
