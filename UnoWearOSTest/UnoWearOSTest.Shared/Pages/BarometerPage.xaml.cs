using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Devices.Sensors;

namespace UnoWearOSTest.Pages {
    public sealed partial class BarometerPage : Page {
        public BarometerPage() {
            this.InitializeComponent();

            Init();
        }

        public void Init() {
            var barometer = Barometer.GetDefault();

            //PressureText.Text = "Waiting for data...";

            barometer.ReadingChanged += Barometer_ReadingChanged;
        }

        private void Barometer_ReadingChanged(Barometer sender, BarometerReadingChangedEventArgs args) {
            PressureText.Text = $"Pressure: {Math.Round(args.Reading.StationPressureInHectopascals, 2)} hPa";
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
