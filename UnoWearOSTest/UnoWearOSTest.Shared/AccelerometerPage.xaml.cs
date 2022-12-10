using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Devices.Sensors;

namespace UnoWearOSTest {
    public sealed partial class AccelerometerPage : Page {
        public AccelerometerPage() {
            this.InitializeComponent();

            Innit();
        }

        public void Innit() {
            var accelometer = Accelerometer.GetDefault();

            //GetCurrentReading not implemented
            //UpdateValues(accelometer.GetCurrentReading());

            accelometer.ReadingChanged += Accelometer_ReadingChanged;
        }

        private void Accelometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args) {
            UpdateValues(args.Reading);
        }

        private void UpdateValues(AccelerometerReading acce, int round = 2) {
            XText.Text = $"X: {MathF.Round((float)acce.AccelerationX, round)}";
            YText.Text = $"Y: {MathF.Round((float)acce.AccelerationY, round)}";
            ZText.Text = $"Z: {MathF.Round((float)acce.AccelerationZ, round)}";
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
