using MediatR;
using RealEstate.Application.Common;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Listings.Commands
{
    public record CreateListingCommand(string Title, decimal Price, double Area, string Location, int BuildYear, bool NearTransport, HouseCondition Condition) : IRequest<int>;
   

    public class CreateListingHandler(IApplicationDbContext context):
        IRequestHandler<CreateListingCommand, int>
    {
        public async Task<int> Handle(CreateListingCommand request,CancellationToken ct)
        {
            var entity = new Property
            {
                Title=request.Title,
                Price=request.Price,
                Area=request.Area,
                Location=request.Location,
                BuildYear=request.BuildYear,
                NearPublicTransport=request.NearTransport,
                Condition=request.Condition

            };
            context.Properties.Add(entity); 
            await context.SaveChangesAsync(ct);

            return entity.Id;
        }
    }
   
}
