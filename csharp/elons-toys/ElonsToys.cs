using System;

class RemoteControlCar
{

    private static readonly int _distancePerDrive = 20;
    private static readonly int _batteryPerDrive = 1;

    private int _distanceTraveled = 0;
    private int _batteryLevel = 100;

    public static RemoteControlCar Buy() =>
        new();

    public string DistanceDisplay() =>
        $"Driven {_distanceTraveled} meters";

    public string BatteryDisplay() => _batteryLevel switch {
        >  0 => $"Battery at {_batteryLevel}%",
        <= 0 => $"Battery empty"
    };

    public void Drive()
    {
        if (_batteryLevel > 0) {
            _distanceTraveled += _distancePerDrive;
            _batteryLevel -= _batteryPerDrive;
        }
    }
}
