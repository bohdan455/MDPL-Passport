namespace MDPL_Passport;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Name.Text = Preferences.Default.Get("Name", "Партія осуджує тебе за поломку проги");

        Position.Text = Preferences.Default.Get("Position", "Партія осуджує тебе за поломку проги"); ;

    }
}

