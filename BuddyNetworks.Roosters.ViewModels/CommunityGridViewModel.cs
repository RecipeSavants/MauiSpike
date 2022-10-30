using System;
using BuddyNetworks.Roosters.Utilities;

namespace BuddyNetworks.Roosters.ViewModels
{
	public class CommunityGrid
	{
		private OwnerViewModel Owner { get; set; }
		public List<CommunityRowViewModel> Rows { get; set; }
		private SearchType Search1 { get; set; }
        private SearchType Search2 { get; set; }
        private SearchType Search3 { get; set; }

        public CommunityGrid(OwnerViewModel o, SearchType s1, SearchType s2, SearchType s3)
		{
			Owner = o;
			Search1 = s1;
			Search2 = s2;
			Search3 = s3;
			Search();
		}

		private void Search()
        {

        }
	}
}

