# Uno WearOS App Test
 Just a fun little after-school project for exploring the possibilities of Uno Platform.

## Operating Systems
- [x] Android
- [x] WearOS
- [ ] iOS
- [ ] WatchOS

## Known Bugs
- Pedometer doesn't report initial data and `GetCurrentReadings()` is not currently supported in UNO.
- When a sensor like `Barometer` or `LightSensor`, etc. is not present in the device, the page won't load, nor will it give any information about it.