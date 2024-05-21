using Microsoft.Extensions.Logging;
using DiplomaBlazor.Data;
using DiplomaBlazor.Services;

namespace DiplomaBlazor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		AddServices(builder.Services);

		return builder.Build();
	}
	private static void AddServices(IServiceCollection services)
	{
		services.AddSingleton<DatabaseContext>()
				.AddTransient<SeedDataService>();
	}
}

