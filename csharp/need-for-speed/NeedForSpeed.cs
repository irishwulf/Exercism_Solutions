using System;

class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _distanceDriven;
    private int _batteryLevel;

    public RemoteControlCar(int speed, int batteryDrain) {
        _distanceDriven = 0;
        _batteryLevel = 100;
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() =>
        _batteryLevel < _batteryDrain;

    public int DistanceDriven() =>
        _distanceDriven;

    public void Drive()
    {
        if (! BatteryDrained()) {
            _distanceDriven += _speed;
            _batteryLevel -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() =>
        new RemoteControlCar(50,4);

    public int RemainingDistance() =>
        _speed * (_batteryLevel / _batteryDrain);
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance) =>
        this.distance = distance;

    public bool TryFinishTrack(RemoteControlCar car) =>
        distance <= car.RemainingDistance();
}
