﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Devices.Sensors;

namespace UnoWearOSTest.Pages {
    public sealed partial class LightsPage : Page {
        public LightsPage() {
            this.InitializeComponent();

            Init();
        }

        public void Init() {
            var lightSensor = LightSensor.GetDefault();

            IlluminanceText.Text = "Waiting for the data...";

            lightSensor.ReadingChanged += LightSensor_ReadingChanged;
        }

        private void LightSensor_ReadingChanged(LightSensor sender, LightSensorReadingChangedEventArgs args) {
            IlluminanceText.Text = $"Illuminance: {args.Reading.IlluminanceInLux} lx";
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
