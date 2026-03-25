using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Persistence;

// Используем Primary Constructor .NET 8 для передачи опций
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    // Наша таблица объявлений
    public DbSet<Property> Properties => Set<Property>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Property>(entity =>
        {
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);

            // Превращаем Enum в строку в базе данных (для удобства чтения SQL)
            entity.Property(e => e.Condition)
                  .HasConversion<string>();
        });
    }
}