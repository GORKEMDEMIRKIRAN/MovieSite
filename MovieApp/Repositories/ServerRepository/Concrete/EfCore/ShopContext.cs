


//====================================
using Microsoft.EntityFrameworkCore;

//====================================
using Entities.RepositoryModels;
//====================================

namespace Repositories.ServerRepository.Concrete.EfCore
{
    public class ShopContext:DbContext
    {
        public DbSet<Category> Categories {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<MovieType> MovieTypes {get;set;}
        public DbSet<MovieCategory> MovieCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlite("Data Source=MovieApp.db"); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>()
                .HasKey(a=>new {a.CategoryId,a.MovieId,a.TypeId});

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.category)
                .WithMany()
                .HasForeignKey(mc => mc.CategoryId);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.movie)
                .WithMany()
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.movietype)
                .WithMany()
                .HasForeignKey(mc => mc.TypeId);
        }
    }
}