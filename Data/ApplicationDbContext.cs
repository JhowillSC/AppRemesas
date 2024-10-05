using AppRemesas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppRemesas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
     public DbSet<Transacciones>Transacciones { get; set; }
      public DbSet<Conversiones>Conversiones { get; set; }
}
