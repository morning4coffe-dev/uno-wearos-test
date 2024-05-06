using System.Collections.ObjectModel;

namespace UnoWearOSTest.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;

    public ObservableCollection<Sample> Samples { get; } =
    [
        new("Light Sensor", typeof(LightSensorViewModel)),
        new("Light Sensor", typeof(LightSensorViewModel))
    ];

    public MainViewModel(
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        GoToSecond = new AsyncRelayCommand<object>(GoToSecondView);
    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }

    private async Task GoToSecondView(object? parameter)
    {
        await _navigator.NavigateViewModelAsync<LightSensorViewModel>(this);
    }

}
