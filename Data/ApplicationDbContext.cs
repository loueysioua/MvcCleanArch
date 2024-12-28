using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Models;

namespace MvcCleanArch.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieUser> MoviesUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieUser>()
            .HasKey(um => new { um.UserId, um.MovieId });

        modelBuilder.Entity<MovieUser>()
            .HasOne(um => um.User)
            .WithMany(u => u.Movies)
            .HasForeignKey(um => um.UserId);

        modelBuilder.Entity<MovieUser>()
            .HasOne(um => um.Movie)
            .WithMany(m => m.Users)
            .HasForeignKey(um => um.MovieId);

        base.OnModelCreating(modelBuilder);
    }

}
