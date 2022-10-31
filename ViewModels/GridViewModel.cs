using System;
using System.Collections.ObjectModel;
using MauiPlanets.Models;

namespace BuddyNetworks.Roosters.ViewModels
{
	public class GridViewModel:BindableObject
	{
        public Page Page { get; set; }
        public Command SelectionChangedCommand { get => new Command(SelectionChanged); }
        private ObservableCollection<Planet> _list1;
        private ObservableCollection<Planet> _list2;
        ObservableCollection<Planet> _list3;


        public GridViewModel(Page page)
		{
            Page = page;
		}

        public ObservableCollection<Planet> List1
        {
            get => _list1;
            set { _list1 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Planet> List2
        {
            get => _list2;
            set { _list2 = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Planet> List3
        {
            get => _list3;
            set { _list3 = value; OnPropertyChanged(); }
        }

        #region private methods

        private async void SelectionChanged(object obj)
        {
            if (obj == null) return;
            await Page.Navigation.PushAsync(new PlanetDetailsPage(obj as Planet));
        }

        #endregion

        #region internal methods

        internal async void OnAppearing()
        {
            try
            {
                /// loading items on appearing as async operation not block the UI
                var p = new List<Planet>();
                var allP = new List<Planet>();
                var t1 = Task.Run(async () => p = await PlanetsService.GetFeaturedPlanets());
                var t2 = Task.Run(async () => allP = await PlanetsService.GetAllPlanets());
                await Task.WhenAll(t1, t2);
                List1 = new ObservableCollection<Planet>(p);
                List2 = new ObservableCollection<Planet>(allP);
                List3 = new ObservableCollection<Planet>(allP);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion
    }
}

