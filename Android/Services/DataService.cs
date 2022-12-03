using BuddyNetworks.Roosters.CosmosClient.Models;

namespace BuddyNetworks.Roosters.Services;

public class DataService
{
    private Dictionary<string, Photo> photos;
    private List<Profile> profiles;

    public DataService()
    {
        photos = new Dictionary<string, Photo>();
        photos.Add("BootSlut", new Photo() { Uri = "https://marketingbuddynetworks.blob.core.windows.net/roosters/m_0006_7.jpg" });
        profiles = new List<Profile>()
        {
            new Profile()
            {
            UserName = "BootSlut",
            Headline = "Fun & Furry Top Man",
            PrimaryPhoto = photos.Where(w=>w.Key=="BootSlut").FirstOrDefault().Value,
            MoreAboutMe = "Hot and horny top man looking to get kinky and put you through your paces!",
            DisplayAge=  39,
            Location=  "Chicago, Il",
            Hood = "Rogers Park",
            When = 1,
            Where = 1,
            Feet = 5,
            Inches = 9,
            Weight = 205,
            }
        };
    }

    public async Task<List<Profile>> GetProfiles()
        => profiles;

    public Profile GetPlanet(string ProfileName)
        => profiles.Where(_profile => _profile.NormalizedUserName == ProfileName.ToLower()).FirstOrDefault();

    public async Task<List<Profile>> GetFeaturedProfiles()
    {
        var rnd = new Random();
        var randomProfiles = profiles.OrderBy(item => rnd.Next());

        return randomProfiles.Take(2).ToList();
    }


}

