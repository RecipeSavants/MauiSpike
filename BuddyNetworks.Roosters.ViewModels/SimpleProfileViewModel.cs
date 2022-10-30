using BuddyNetworks.Roosters.CosmosClient.Models;
using BuddyNetworks.Roosters.ServiceModels;
using BuddyNetworks.Roosters.Utilities;

namespace BuddyNetworks.Roosters.ViewModels;

public class SimpleProfileViewModel
{
    public string UserName { get; set; }
    public string Headline { get; set; }
    public double Distance { get; set; }
    public string Photo { get; set; }
    private OwnerViewModel owner { get; set; }

    public SimpleProfileViewModel()
    {

    }

    public SimpleProfileViewModel(OwnerViewModel o)
    {
        owner = o;
    }

    public SimpleProfileViewModel Transform(CommunityGridItemViewModel model)
    {
        var point1 = new Point(model.Lat, model.Long);
        var point2 = new Point(owner.Latitude, owner.Longitude);
        return new SimpleProfileViewModel()
        {
            UserName = model.UserName,
            Headline = model.Headline,
            Photo = model.Uri,
            Distance = new Distance().HaversineDistance(point1, point2, owner.DistanceUnit)
        };
    }
}

