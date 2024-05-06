using Microsoft.UI.Dispatching;
using Windows.Devices.Sensors;
using Windows.UI;

namespace UnoWearOSTest.Presentation;

public partial class LightSensorViewModel : ObservableObject
{
    private LightSensor? _lightSensor;

    [ObservableProperty]
    private bool _readingChangedAttached;

    [ObservableProperty]
    private string? _sensorStatus;

    [ObservableProperty]
    private string? _lux;

    [ObservableProperty]
    private bool _noSensor = false;

    [ObservableProperty]
    private Brush _backgroundBrush = new SolidColorBrush(Microsoft.UI.Colors.Transparent);

    private DispatcherQueue _dispatcherQueue => DispatcherQueue.GetForCurrentThread();

    public LightSensorViewModel()
    {
        Initialize();
    }

    public void Initialize()
    {
        _lightSensor = LightSensor.GetDefault();
        OnPropertyChanged(nameof(LightSensorAvailable));

        if (_lightSensor == null)
        {
            NoSensor = true;
            return;
        }

        //TODO: use Uno.Disposables
        _lightSensor.ReadingChanged -= LightSensor_ReadingChanged;
        _lightSensor.ReadingChanged += LightSensor_ReadingChanged;
    }

    public bool LightSensorAvailable => _lightSensor != null;

    private void LightSensor_ReadingChanged(LightSensor sender, LightSensorReadingChangedEventArgs args)
    {
        _dispatcherQueue.TryEnqueue(DispatcherQueuePriority.Normal, () =>
        {
            Lux = string.Format("{0:0}", Math.Round(args.Reading.IlluminanceInLux));

            double ratio = Math.Max(Math.Min(args.Reading.IlluminanceInLux, 1000), 0) / 2000.0;

            byte grayValue = (byte)(255 * ratio);
            BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, grayValue, grayValue, grayValue));
        });
    }
}
