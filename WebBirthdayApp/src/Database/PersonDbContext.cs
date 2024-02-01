using Microsoft.EntityFrameworkCore;
using WebBirthdayApp.Database.Config;
using WebBirthdayApp.Models;

namespace WebBirthdayApp.Database;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) 
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfig());
    }
    
    
    public DbSet<Person> Person { get; set; }
}