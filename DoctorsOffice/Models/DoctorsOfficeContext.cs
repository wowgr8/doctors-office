using Microsoft.EntityFrameworkCore;

namespace DoctorsOffice.Models
{
  public class DoctorsOfficeContext : DbContext
  {
    public DbSet<DatabaseTablePlaceholder> DatabaseTablePlaceholder { get; set; }
    public DoctorsOfficeContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}