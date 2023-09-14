using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<PkOwner> PkOwners { get; set; }
        public DbSet<PkCategory> pkCategories { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Reviewer> reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PkCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PkCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.pkCategories)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PkCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.pkCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PkOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PkOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PkOwners)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PkOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PkOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
