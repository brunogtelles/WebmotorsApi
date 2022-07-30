using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WebmotorsApi.Models
{
  public class WebmotorsContext : DbContext
  {
    public WebmotorsContext (DbContextOptions<WebmotorsContext> options) : base (options) { }

    public DbSet<WebmotorsItem> WebmotorsItems { get; set; } = null!;
  }
}
