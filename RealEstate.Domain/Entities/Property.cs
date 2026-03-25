// RealEstate.Domain/Entities/Property.cs
namespace RealEstate.Domain.Entities;

public class Property
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Area { get; set; }
    public string Location { get; set; } = string.Empty;
    public int BuildYear { get; set; }
    public bool NearPublicTransport { get; set; }
    public HouseCondition Condition { get; set; }
}