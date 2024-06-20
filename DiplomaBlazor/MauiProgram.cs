using CommunityToolkit.Maui;
using DiplomaBlazor.ViewModels;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

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
			})
			.UseMauiCommunityToolkit();

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMemoryCache();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		AddServices(builder.Services);

		return builder.Build();
	}
	private static void AddServices(IServiceCollection services)
	{
		services.AddSingleton<AppViewModel>()
			.AddSingleton<MauiInterop>()
			.AddSingleton<AppState>();

		services.AddSingleton<DatabaseContext>()
				.AddTransient<SeedDataService>();
				
		services.AddTransient<AuthService>()
                .AddSingleton<TripsService>()
				.AddSingleton<DocumentsService>()
				.AddTransient<DropDownsService>()
				.AddSyncfusionBlazor();
	}
}

