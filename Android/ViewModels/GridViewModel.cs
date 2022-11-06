using System;
using System.Collections.ObjectModel;
using BuddyNetworks.Roosters.CosmosClient.Models;
using MauiPlanets.Models;

namespace BuddyNetworks.Roosters.ViewModels
{
	public class GridViewModel:BindableObject
	{
        public Page Page { get; set; }
        public Command SelectionChangedCommand { get => new Command(SelectionChanged); }
        private ObservableCollection<Profile> _list1;
        private ObservableCollection<Profile> _list2;
        private ObservableCollection<Profile> _list3;


        public GridViewModel(Page page)
		{
            Page = page;
		}

        public ObservableCollection<Profile> List1
        {
            get => _list1;
            set { _list1 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Profile> List2
        {
            get => _list2;
            set { _list2 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Profile> List3
        {
            get => _list3;
            set { _list3 = value; OnPropertyChanged(); }
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
                List1 = new ObservableCollection<Profile>(p);
                List2 = new ObservableCollection<Profile>(allP);
                List3 = new ObservableCollection<Profile>(allP);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion
    }
}

