namespace MDPL_Passport.Pages;

public partial class VibrationPage : ContentPage
{
	public VibrationPage()
	{
		InitializeComponent();
	}

    private void StartVibration(object sender, EventArgs e)
    {
        const int secondsToVibrate = 5;
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);
        Vibration.Default.Vibrate(vibrationLength);
    }
}