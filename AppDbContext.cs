using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Role> Roles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}