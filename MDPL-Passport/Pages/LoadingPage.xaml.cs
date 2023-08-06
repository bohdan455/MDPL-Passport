using MDPL_Passport.Services;

namespace MDPL_Passport.Pages;

public partial class LoadingPage : ContentPage
{
    private readonly IAuthService _authService;

    public LoadingPage(IAuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }
    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if(await _authService.IsAuthenticated())
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}