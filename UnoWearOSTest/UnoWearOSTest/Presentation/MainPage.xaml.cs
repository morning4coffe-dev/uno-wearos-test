namespace UnoWearOSTest.Presentation;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel;

    public MainPage()
    {
        this.InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var dc = ((FrameworkElement)Content).DataContext;
    }
}
