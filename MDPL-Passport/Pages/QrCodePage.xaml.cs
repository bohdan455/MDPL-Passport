using MDPL_Passport.Services;
using QRCoder;
using System.Xml.Linq;

namespace MDPL_Passport.Pages;

public partial class QrCodePage : ContentPage
{
    private readonly IEncryptingService _encryptingService;

    public QrCodePage(IEncryptingService encryptingService)
	{
		InitializeComponent();
        _encryptingService = encryptingService;
    }
    private void OnGenerateClicked(object sender, EventArgs e)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        var name = Preferences.Default.Get("Name", "Партія осуджує тебе за поломку проги");

        var position = Preferences.Default.Get("Position", "Партія осуджує тебе за поломку проги"); ;
        var encryptedCode = _encryptingService.EncryptString($"{name}&&&{position}");

        QRCodeData qrCodeData = qrGenerator.CreateQrCode(encryptedCode, QRCodeGenerator.ECCLevel.L);
        PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
    }
}