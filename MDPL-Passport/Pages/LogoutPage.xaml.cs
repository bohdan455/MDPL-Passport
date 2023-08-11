using MDPL_Passport.Services;

namespace MDPL_Passport.Pages;

public partial class LogoutPage : ContentPage
{
    private readonly IAuthService _authService;

    public LogoutPage(IAuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await _authService.Logout();
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}