namespace MauiPlanets;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Titillium-Semibold.otf", "RegularFont");
                fonts.AddFont("Titillium-Bold.otf", "MediumFont");
                fonts.AddFont("Titillium-BoldUpright.otf", "BoldFont");
                fonts.AddFont("Metro.otf", "Display");
			})
            .ConfigureLifecycleEvents(events =>
            {
            });

		return builder.Build();
	}
}

