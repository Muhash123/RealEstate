using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Listings.Queries;

// Запросы (Queries)
public record GetAllListingsQuery() : IRequest<List<Property>>;
public record GetListingByIdQuery(int Id) : IRequest<Property?>;

// Хендлер для обоих запросов
public class ListingQueriesHandler(IApplicationDbContext context)
    : IRequestHandler<GetAllListingsQuery, List<Property>>,
      IRequestHandler<GetListingByIdQuery, Property?>
{
    // 1. Метод для получения ВСЕХ записей
    public async Task<List<Property>> Handle(GetAllListingsQuery request, CancellationToken cancellationToken)
    {
        return await context.Properties
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    // 2. Метод для получения ОДНОЙ записи по ID
    public async Task<Property?> Handle(GetListingByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.Properties
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
    }
}