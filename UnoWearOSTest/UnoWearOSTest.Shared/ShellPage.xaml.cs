using Microsoft.UI.Xaml.Controls;
using UnoWearOSTest.Pages;

namespace UnoWearOSTest {
    public sealed partial class ShellPage : Page {
        public static ShellPage Current;

        public ShellPage() {
            this.InitializeComponent();
            Current = this;
            ShellFrame.Content = new MainPage();

            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, args) => {
                if(!ShellPage.Current.Frame.CanGoBack) {
                    return;
                }
                ShellPage.Current.Frame.GoBack();
                args.Handled = true;
            };
        }
    }
}
