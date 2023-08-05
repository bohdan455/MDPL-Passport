using MDPL_Passport.Services;

namespace MDPL_Passport.Pages;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage(AuthService authService)
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