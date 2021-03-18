using Microsoft.EntityFrameworkCore;

namespace AMC.Models
{
  public class AMCContext : DbContext
  {
    public virtual DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MovieActor { get; set; }

    public AMCContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}