using BuddyNetworks.Roosters.Core.Models;

namespace BuddyNetworks.Roosters.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(Profile profile)
	{
		InitializeComponent();

		this.BindingContext = profile;
    }

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopAsync();
    }
}
