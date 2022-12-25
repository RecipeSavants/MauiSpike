using System;
using BuddyNetworks.Roosters.Core.Models;

namespace BuddyNetworks.Roosters.Core.Services
{
    public class DataService
    {
        private Dictionary<string, Photo> photos;
        private List<Profile> profiles;

        public DataService()
        {
            photos = new Dictionary<string, Photo>();
            photos.Add("BootSlut", new Photo() { Uri = "https://marketingbuddynetworks.blob.core.windows.net/roosters/m_0006_7.jpg" });
            photos.Add("CumWhore", new Photo() { Uri = "https://marketingbuddynetworks.blob.core.windows.net/roosters/m_0005_6.jpg" });
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
            Communities = new List<string>() { "Leather Guys"}
            },
            new Profile()
            {
            UserName = "CumWhore",
            Headline = "Hunky and Hairy TOTAL Bottom",
            PrimaryPhoto = photos.Where(w=>w.Key=="CumWhore").FirstOrDefault().Value,
            MoreAboutMe = "Breed and Seed and Leave!",
            DisplayAge=  45,
            Location=  "Chicago, Il",
            Hood = "Old Town",
            When = 1,
            Where = 1,
            Feet = 5,
            Inches = 9,
            Weight = 195,
            Communities = new List<string>() {"Leather Guys", "Muscle Guys"}
            }
        };
        }

        public async Task<List<Profile>> GetProfiles()
            => profiles;

        public Profile GetProfile(string ProfileName)
            => profiles.Where(_profile => _profile.NormalizedUserName == ProfileName.ToLower()).FirstOrDefault();

        public List<Profile> GetCommunityProfiles(string community)
        {
            return profiles.Where(w => w.Communities.Contains(community)).ToList();
        }

        public async Task<List<Profile>> GetFeaturedProfiles()
        {
            var rnd = new Random();
            var randomProfiles = profiles.OrderBy(item => rnd.Next());

            return randomProfiles.Take(2).ToList();
        }


    }
}

