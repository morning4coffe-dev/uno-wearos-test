using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace UnoWearOSTest {
    public sealed partial class GeolocatorPage : Page {
        public GeolocatorPage() {
            this.InitializeComponent();
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
