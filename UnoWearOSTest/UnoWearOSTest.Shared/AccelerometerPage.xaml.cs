using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Devices.Sensors;

namespace UnoWearOSTest {
    public sealed partial class AccelerometerPage : Page {
        public AccelerometerPage() {
            this.InitializeComponent();

            var accelometer = Accelerometer.GetDefault();
            accelometer.ReadingChanged += (s, e) => {
                XText.Text = MathF.Round((float)e.Reading.AccelerationX, 2).ToString();
                YText.Text = MathF.Round((float)e.Reading.AccelerationY, 2).ToString();
                ZText.Text = MathF.Round((float)e.Reading.AccelerationZ, 2).ToString();
            };
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
