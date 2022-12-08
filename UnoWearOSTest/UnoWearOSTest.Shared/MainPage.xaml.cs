using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Phone.Devices.Notification;

namespace UnoWearOSTest {
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        public void OnAccelerometer_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(AccelerometerPage));
        }

        public void OnGeolocator_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.Navigate(typeof(AccelerometerPage));
        }

        public void OnVibration_Click(object sender, RoutedEventArgs e) {
            var vibrationDevice = VibrationDevice.GetDefault();
            if(vibrationDevice is not null)
                vibrationDevice.Vibrate(TimeSpan.FromMilliseconds(1000));
        }
    }
}
