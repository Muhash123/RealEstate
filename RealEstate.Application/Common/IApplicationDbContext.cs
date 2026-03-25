using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Common;

public interface IApplicationDbContext
{
 
    DbSet<Property> Properties { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}