using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
#if ANDROID
using Windows.Phone.Devices.Notification;
#endif

namespace UnoWearOSTest.Pages {
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        public void OnAccelerometer_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(AccelerometerPage));
        }

        public void OnMagnetometer_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(MagnetometerPage));
        }

        public void OnGeolocator_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(GeolocatorPage));
        }

        public void OnPedometer_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(PedometerPage));
        }

        public void OnBarometer_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(BarometerPage));
        }

        public void OnLights_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(LightsPage));
        }

        public void OnVibration_Click(object sender, RoutedEventArgs e) {
#if ANDROID
            var vibrationDevice = VibrationDevice.GetDefault();
            if(vibrationDevice is not null)
                vibrationDevice.Vibrate(TimeSpan.FromMilliseconds(1000));
#endif
        }
    }
}
