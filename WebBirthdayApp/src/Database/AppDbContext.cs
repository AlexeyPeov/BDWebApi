using Microsoft.EntityFrameworkCore;
using WebBirthdayApp.Database.Config;
using WebBirthdayApp.Models;

namespace WebBirthdayApp.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfig());
        modelBuilder.ApplyConfiguration(new ImageConfig());
        
    }
    
    public DbSet<Person> Person { get; set; }
    public DbSet<Image> Image { get; set; }
}