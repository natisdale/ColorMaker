using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

    void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
		if (!isRandom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }	
    }

	private void SetColor(Color color)
	{
		Debug.WriteLine(color.ToString());
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		hexValue = color.ToHex();
		lblHex.Text = color.ToHex();
	}

    void btnRandom_Clicked(System.Object sender, System.EventArgs e)
    {
		isRandom = true;
		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 256),
			random.Next(0, 256),
			random.Next(0, 256));

		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
		isRandom = false;
    }

    private async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color coppied",
			CommunityToolkit.Maui.Core.ToastDuration.Short,
			12);
		await toast.Show();
    }
}


