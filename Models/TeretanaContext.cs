using Microsoft.EntityFrameworkCore;

namespace Models
{

    public class TeretanaContext : DbContext
    {

        public DbSet<Teretana> Teretane { get; set; }
        public DbSet<Trening> Treninzi { get; set; }
        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Termin> Termini { get; set; }
        public DbSet<Vrsta> Vrste { get; set; }
        

        public TeretanaContext(DbContextOptions options) : base(options)
        {

        }
      /*  protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Teretana>()
            .HasMany(tr => tr.trening)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
mb.Entity<Trening>()
.HasMany(m => m.vezbaci)
.WithOne()
.OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Vezbac>()
            .HasMany(s => s.partneri)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(mb);
        }*/
    }
}