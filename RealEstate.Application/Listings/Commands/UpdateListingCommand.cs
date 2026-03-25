using MediatR;
using RealEstate.Application.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Listings.Commands
{
    public record UpdateListingCommand(
        int Id,
        decimal Price,
        HouseCondition Condition) : IRequest<bool>;

    public record UpdateListingHandler(IApplicationDbContext context)
         : IRequestHandler<UpdateListingCommand, bool>
    {

        public async Task<bool> Handle(UpdateListingCommand request, CancellationToken ct)
        {
            var entity = await context.Properties.FindAsync([request.Id], ct);

            if (entity == null)
            {
                return false;
            }
            entity.Price = request.Price;
            entity.Condition = request.Condition;
            await context.SaveChangesAsync(ct);

            return true;
        }



    }
}
