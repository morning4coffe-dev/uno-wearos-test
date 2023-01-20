# Uno WearOS App Test
 Just a fun little after-school project for exploring the possibilities of Uno Platform.

## Operating Systems
- [x] Android
- [x] WearOS
- [ ] iOS - Not tested
- [ ] WatchOS - Not tested

## How-to Run It On WearOS
1. Follow the tutorial on how to install the latest version of [Uno Platform](https://platform.uno/docs/articles/get-started.html) on your computer.
2. Connect your WearOS watch to your Wi-Fi network.
3. On your watch, go to Settings > About watch > Software info and tap a few times on the Software version to enable Developer options.
4. Go back to Settings and open the Developer options menu. Turn on ADB debugging and Debug over Wi-Fi.
5. Go to the Wi-Fi settings on your watch and click on the currently connected Wi-Fi network to get the IP address of your watch.
6. On your computer, open the command prompt and type: `adb connect {your_watch_IP_address}` to connect to your watch. A Allow Debugging prompt should appear on your watch, click OK.
7. In Visual Studio, switch to the Android platform and open the project containing the app you want to run. Your WearOS watch should appear under Android Local Devices.
8. Click on Start Without Debugging to run the app on your watch.

## Workarounds 
- To see accurate speed and heading information in the Geolocator on your watch, some activity tracking must be enabled first (e.g. Walking, Running, Cycling, etc.)

## Known Bugs
- Pedometer doesn't report initial data and `GetCurrentReadings()` is not currently supported in UNO.
- When a sensor like `Barometer` or `LightSensor`, etc. is not present in the device, the page won't load, nor will it give any information about it.
- I haven't been able to get debugging to work on the watch yet.