using Accruent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accruent.Data.Contexts;

public class AccruentDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Movement> Movements { get; set; }

    public AccruentDbContext(DbContextOptions<AccruentDbContext> options, bool skipCreation = false) : base(options)
    {
        if (!skipCreation && Database.EnsureCreated())
        {
            Products!.AddRange(new List<Product>()
            {
                new() 
                {
                    Code = "A",
                    Name = "NameA",
                    Id = Guid.NewGuid()
                },
                new() 
                {
                    Code = "B",
                    Name = "NameB",
                    Id = Guid.NewGuid()
                },
                new() 
                {
                    Code = "C",
                    Name = "NameC",
                    Id = Guid.NewGuid()
                }
            });
            SaveChanges();
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccruentDbContext).Assembly);
    }
}
