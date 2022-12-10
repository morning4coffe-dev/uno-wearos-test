using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Devices.Geolocation;

namespace UnoWearOSTest.Pages {
    public sealed partial class GeolocatorPage : Page {
        public GeolocatorPage() {
            this.InitializeComponent();

            Innit();
        }

        public async void Innit() {
            var geolocatorAccess = await Geolocator.RequestAccessAsync();
            if(geolocatorAccess == GeolocationAccessStatus.Allowed) {
                var geolocator = new Geolocator();

                var geo = await geolocator.GetGeopositionAsync();
                UpdateValues(geo.Coordinate);

                geolocator.PositionChanged += Geolocator_PositionChanged;
            } else {
                LocationNull.Visibility = Visibility.Visible;
                LocationNull.Text = $"Location Access: {geolocatorAccess}";
            }
        }

        /// <summary>
        /// The accuracy of the location information provided by this method depends on the source.
        /// The latitude and longitude values may vary within the ranges specified in the following documentation:
        /// <a href = "https://learn.microsoft.com/en-us/uwp/api/windows.devices.geolocation"/>
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="args">The event arguments containing the location data.</param>
        private void Geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args) {
            UpdateValues(args.Position.Coordinate);
        }

        private void UpdateValues(Geocoordinate geo, int round = 4) {
            LongitudeText.Text = $"Longitude: {Math.Round((float)geo.Longitude, round)} °";
            LatitudeText.Text = $"Latitude: {Math.Round((float)geo.Latitude, round)} °";
            AltitudeText.Text = $"Altitude: {Math.Round((float?)geo.Altitude ?? 0f, round)} m";
            HeadingText.Text = $"Heading: {Math.Round((float?)geo.Heading ?? 0f, round)} °";
            SpeedText.Text = $"Speed: {Math.Round((float?)geo.Speed ?? 0f, round)} m/s";
            AccuracyText.Text = $"Accuracy: {Math.Round((float)geo.Accuracy, round)} m";
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
