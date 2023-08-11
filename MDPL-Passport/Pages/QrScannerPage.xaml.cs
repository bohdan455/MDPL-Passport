using Camera.MAUI;
using Camera.MAUI.ZXingHelper;
using MDPL_Passport.Services;
using System.Diagnostics;

namespace MDPL_Passport.Pages;

public partial class QrScannerPage : ContentPage
{
    private readonly IEncryptingService _encryptingService;

    public QrScannerPage(IEncryptingService encryptingService)
	{

        InitializeComponent();
        _encryptingService = encryptingService;
        //cameraView.CamerasLoaded += CameraView_CamerasLoaded;
        //cameraView.BarcodeDetected += CameraView_BarcodeDetected;
        //cameraView.BarCodeOptions = new BarcodeDecodeOptions
        //{
        //    AutoRotate = true,
        //    PossibleFormats = { ZXing.BarcodeFormat.QR_CODE },
        //    ReadMultipleCodes = false,
        //    TryHarder = true,
        //    TryInverted = true
        //};
        //cameraView.BarCodeDetectionFrameRate = 10;
        //cameraView.BarCodeDetectionMaxThreads = 5;
        //cameraView.ControlBarcodeResultDuplicate = true;
        //cameraView.BarCodeDetectionEnabled = true;
    }
    private void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 0)
        {
            cameraView.Camera = cameraView.Cameras[0];
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }
    private void CameraView_BarcodeDetected(object sender, BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var qrText = args.Result[0].Text;
            var decryptedTextArray = _encryptingService.DecryptString(qrText).Split("&&&");
            var name = decryptedTextArray[0];
            var position = decryptedTextArray[1];
            NameOfScannedUser.Text = name;
            PositionOfScannedUser.Text = position;
        });
    }
}