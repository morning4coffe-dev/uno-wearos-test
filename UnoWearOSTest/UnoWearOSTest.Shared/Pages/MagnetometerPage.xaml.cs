using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Devices.Sensors;

namespace UnoWearOSTest.Pages {
    public sealed partial class MagnetometerPage : Page {
        public MagnetometerPage() {
            this.InitializeComponent();

            Init();
        }

        public void Init() {
            var magnetometer = Magnetometer.GetDefault();

            //GetCurrentReading not implemented
            //UpdateValues(magnetometer.GetCurrentReading());

            magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
        }

        private void Magnetometer_ReadingChanged(Magnetometer sender, MagnetometerReadingChangedEventArgs args) {
            UpdateValues(args.Reading);
        }

        private void UpdateValues(MagnetometerReading mag, int round = 2) {
            XText.Text = $"X: {MathF.Round((float)mag.MagneticFieldX, round)}";
            YText.Text = $"Y: {MathF.Round((float)mag.MagneticFieldY, round)}";
            ZText.Text = $"Z: {MathF.Round((float)mag.MagneticFieldZ, round)}";
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
