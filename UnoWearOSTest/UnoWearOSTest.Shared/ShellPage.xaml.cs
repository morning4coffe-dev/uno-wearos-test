using Microsoft.UI.Xaml.Controls;

namespace UnoWearOSTest {
    public sealed partial class ShellPage : Page {
        public static ShellPage Current;

        public ShellPage() {
            this.InitializeComponent();
            Current = this;
            ShellFrame.Content = new MainPage();
        }
    }
}
