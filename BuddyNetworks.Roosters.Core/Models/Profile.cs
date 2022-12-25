﻿using System;
namespace BuddyNetworks.Roosters.Core.Models
{
	public class Profile
	{
        public string UserName { get; set; }
        public string Headline { get; set; }
        public Photo PrimaryPhoto { get; set; }
        public string MoreAboutMe { get; set; }
        public int DisplayAge { get; set; }
        public string Location { get; set; }
        public string Hood { get; set; }
        public int When { get; set; }
        public int Where { get; set; }
        public int Feet { get; set; }
        public int Inches { get; set; }
        public int Weight { get; set; }
        public string NormalizedUserName { get; set; }
        public List<string> Communities { get; set; }

        public Profile()
        {
            Communities = new List<string>();
        }
    }
}
