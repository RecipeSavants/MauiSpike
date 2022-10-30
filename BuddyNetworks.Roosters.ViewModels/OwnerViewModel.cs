using System;
using BuddyNetworks.Roosters.Utilities;

namespace BuddyNetworks.Roosters.ViewModels
{
	public class OwnerViewModel
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public DistanceUnit DistanceUnit { get; set; }
	}
}

