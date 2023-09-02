namespace MDPL_Passport.Pages;

public partial class VibrationPage : ContentPage
{
	public VibrationPage()
	{
		InitializeComponent();
	}

    private void DefaultVibration(object sender, EventArgs e)
    {
        Vibration.Default.Cancel();
        const int secondsToVibrate = 5;
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);
        Vibration.Default.Vibrate(vibrationLength);
    }

    private async void PremiumVibration(object sender, EventArgs e)
    {
        Vibration.Default.Cancel();

        for (int i = 0; i < 5; i++)
        {
            TimeSpan vibrationLength = TimeSpan.FromSeconds(1);
            Vibration.Default.Vibrate(vibrationLength);
            await Task.Delay(1000);
        }
    }

    private async void CockuldVibration(object sender, EventArgs e)
    {
        Vibration.Default.Cancel();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vibration.Default.Vibrate(100);
                await Task.Delay(100);
            }
            Vibration.Default.Vibrate(1000);
            await Task.Delay(1000);
        }
    }
}