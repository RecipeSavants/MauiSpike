using Microsoft.Maui.Controls.Hosting;

namespace BuddyNetworks.Roosters.Views;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
	}

	async void ExploreNow_Clicked(System.Object sender, System.EventArgs e)
	{
		Application.Current.MainPage = new NavigationPage(new GridViewPage());
	}
}
