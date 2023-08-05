using MDPL_Passport.Pages;
using MDPL_Passport.Services;
using Microsoft.Extensions.Logging;

namespace MDPL_Passport;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<VibrationPage>();

		builder.Services.AddTransient<AuthService>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
