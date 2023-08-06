using MDPL_Passport.Services;

namespace MDPL_Passport.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IAuthService _authService;

    public LoginPage(IAuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    private async void TryLogin(object sender, EventArgs e)
    {
        if (await _authService.TryLogin(LoginEntry.Text, PasswordEntry.Text))
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}