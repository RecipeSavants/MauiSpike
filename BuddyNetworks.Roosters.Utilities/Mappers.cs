using System;
namespace BuddyNetworks.Roosters.Utilities
{
	public class Mappers
	{
        public string MapSearchLabel(SearchType value)
        {
            switch (value)
            {
                case SearchType.Bears:
                    return "Bears";
                    break;
                case SearchType.Leather:
                    return "Leather";
                    break;
                case SearchType.Muscle_Dads:
                    return "Muscle Dads";
                    break;
                default:
                    return "";
            }
        }
    }
}

