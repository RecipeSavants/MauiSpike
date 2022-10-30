using System;
using BuddyNetworks.Roosters.CosmosClient.Models;
using BuddyNetworks.Roosters.ServiceModels;
using BuddyNetworks.Roosters.Utilities;

namespace BuddyNetworks.Roosters.ViewModels
{
    public class CommunityRowViewModel
    {
        public List<SimpleProfileViewModel> Items { get; set; }
        public string Label { get; set; }
        public int SortOrder { get; set; }
        private OwnerViewModel owner { get; set; }

        public CommunityRowViewModel()
        {
        }

        public CommunityRowViewModel(OwnerViewModel o)
        {
            owner = o;
        }

        public async Task<CommunityRowViewModel> Search(SearchType search, int sortOrder)
        {
            Label = new Mappers().MapSearchLabel(search);
            SortOrder = sortOrder;
            //perform search and call transform
            return await Transform(new List<CommunityGridItemViewModel>()); //change planent service to call dummy data and see if it works
        }

        private async Task<CommunityRowViewModel> Transform(List<CommunityGridItemViewModel> model)
        {
            List<SimpleProfileViewModel> items = new List<SimpleProfileViewModel>();
            SimpleProfileViewModel transform = new SimpleProfileViewModel(owner);
            foreach (var item in model)
            {
                items.Add(transform.Transform(item));
            }
            return new CommunityRowViewModel()
            {
                Items = items,
                Label = Label,
                SortOrder = SortOrder
            };
        }
    }
}

