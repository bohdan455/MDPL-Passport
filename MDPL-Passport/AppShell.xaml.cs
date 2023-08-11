using MDPL_Passport.Pages;

namespace MDPL_Passport;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage),typeof(MainPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(VibrationPage), typeof(VibrationPage));
        Routing.RegisterRoute(nameof(QrCodePage), typeof(QrCodePage));
        Routing.RegisterRoute(nameof(QrScannerPage), typeof(QrScannerPage));
        Routing.RegisterRoute(nameof(LogoutPage), typeof(LogoutPage));
    }
}
