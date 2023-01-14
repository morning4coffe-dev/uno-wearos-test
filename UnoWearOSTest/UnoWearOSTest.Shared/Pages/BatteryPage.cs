using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Timers;
using Windows.System.Power;

namespace UnoWearOSTest.Pages {
    public sealed partial class BatteryPage : Page {
        public BatteryPage() {
            this.InitializeComponent();

            Init();
        }

        public void Init() {
            BatteryPercentageText.Text = $"Percentage: {PowerManager.RemainingChargePercent} %";
            BatteryStatusText.Text = $"Status: {PowerManager.BatteryStatus}";
            EnergySaverStatusText.Text = $"Energy Saver: {PowerManager.EnergySaverStatus}";
            PowerSupplyStatusText.Text = $"Power Supply: {PowerManager.PowerSupplyStatus}";

            Timer timer = new() {
                Interval = new TimeSpan(0, 5, 0).TotalMicroseconds
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            
            PowerManager.BatteryStatusChanged += PowerManager_BatteryStatusChanged;
            PowerManager.EnergySaverStatusChanged += PowerManager_EnergySaverStatusChanged;
            PowerManager.PowerSupplyStatusChanged += PowerManager_PowerSupplyStatusChanged;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            BatteryPercentageText.Text = $"{PowerManager.RemainingChargePercent} %";
        }

        private void PowerManager_BatteryStatusChanged(object sender, object e) {
            BatteryStatusText.Text = $"Status: {PowerManager.BatteryStatus}";
        }

        private void PowerManager_EnergySaverStatusChanged(object sender, object e) {
            EnergySaverStatusText.Text = $"Energy Saver: {PowerManager.EnergySaverStatus}";
        }

        private void PowerManager_PowerSupplyStatusChanged(object sender, object e) {
            PowerSupplyStatusText.Text = $"Power Supply: {PowerManager.PowerSupplyStatus}";
        }

        public void OnBackButton_Click(object sender, RoutedEventArgs e) {
            ShellPage.Current.Frame.GoBack();
        }
    }
}
