using MediatR;
using RealEstate.Application.Common;

namespace RealEstate.Application.Listings.Commands;

public record DeleteListingCommand(int Id) : IRequest<bool>;

public class DeleteListingHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteListingCommand, bool>
{
    // Убедись, что метод Task<bool>, называется Handle 
    // и принимает (DeleteListingCommand, CancellationToken)
    public async Task<bool> Handle(DeleteListingCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Properties.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            return false;
        }

        context.Properties.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}