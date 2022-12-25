using System;
using System.Collections.ObjectModel;
using BuddyNetworks.Roosters.Core.Models;
using BuddyNetworks.Roosters.Core.Services;

namespace BuddyNetworks.Roosters.iOS.ViewModels
{
	public class GridViewModel:BindableObject
	{
        public Page Page { get; set; }
        public Command SelectionChangedCommand { get => new Command(SelectionChanged); }
        private ObservableCollection<Profile> _featuredProfiles;
        private ObservableCollection<Profile> _community1;
        private ObservableCollection<Profile> _community2;
        private ObservableCollection<Profile> _allProfiles;
        private List<string> _communities;
        private string _communityLabel1;
        private string _communityLabel2;
        private string _communityLabel;

        public GridViewModel()
        {
            _communities = new List<string>();
        }

        public GridViewModel(Page page)
		{
            _communities = new List<string>();
            Page = page;
		}

        public string Communities
        {
            get => _communityLabel;
            set { _communityLabel = value; OnPropertyChanged(); }
        }

        public string CommunityLabel1
        {
            get => _communityLabel1;
            set { _communityLabel1 = value; OnPropertyChanged(); }
        }

        public string CommunityLabel2
        {
            get => _communityLabel2;
            set { _communityLabel2 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Profile> FeaturedProfiles
        {
            get => _featuredProfiles;
            set { _featuredProfiles = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Profile> Community1
        {
            get => _community1;
            set { _community1 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Profile> Community2
        {
            get => _community2;
            set { _community2 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Profile> AllProfiles
        {
            get => _allProfiles;
            set { _allProfiles = value; OnPropertyChanged(); }
        }

        #region private methods

        private async void SelectionChanged(object obj)
        {
            if (obj == null) return;
            await Page.Navigation.PushAsync(new ProfilePage(obj as Profile));
        }

        #endregion

        #region internal methods

        internal async void OnAppearing()
        {
            try
            {
                /// loading items on appearing as async operation not block the UI
                var p = new List<Profile>();
                var allP = new List<Profile>();
                var data = new DataService();
                var t1 = Task.Run(async () => p = await data.GetFeaturedProfiles());
                var t2 = Task.Run(async () => allP = await data.GetProfiles());
                await Task.WhenAll(t1, t2);
                FeaturedProfiles = new ObservableCollection<Profile>(p);
                Community1 = new ObservableCollection<Profile>(allP.Where(w => w.Communities.Contains("Leather Guys")).ToList());
                Community2 = new ObservableCollection<Profile>(allP.Where(w => w.Communities.Contains("Muscle Guys")).ToList());
                AllProfiles = new ObservableCollection<Profile>(allP);
                _communities.Add("Muscle Guys");
                _communities.Add("Leather Guys");
                CommunityLabel1 = "Leather Guys ";
                CommunityLabel2 = "Muscle Guys ";
                Communities = String.Join(",", _communities);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion
    }
}

