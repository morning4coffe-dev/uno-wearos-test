using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Devices.Sensors;

namespace UnoWearOSTest.Pages {
    public sealed partial class PedometerPage : Page {
        public PedometerPage() {
            this.InitializeComponent();

            Init();
        }

        public async void Init() {
            var pedometer = await Pedometer.GetDefaultAsync();

            StepsText.Text = "Waiting for data...";
            pedometer.ReportInterval = 200;

            pedometer.ReadingChanged += Pedometer_ReadingChanged;
        }

        private void Pedometer_ReadingChanged(Pedometer sender, PedometerReadingChangedEventArgs args) {
            StepsText.Text = $"Steps: {args.Reading.CumulativeSteps}";
            DurationText.Text = $"Duration: {args.Reading.CumulativeStepsDuration.TotalSeconds}";
            TimestampText.Text = args.Reading.Timestamp.ToString("R");
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
