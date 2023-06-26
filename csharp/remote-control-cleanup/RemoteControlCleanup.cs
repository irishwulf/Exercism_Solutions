public class RemoteControlCar
{
    private Speed currentSpeed;
    public string CurrentSponsor { get; private set; }
    public ITelemetry Telemetry { get; }

    protected enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    protected struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }


    public RemoteControlCar() =>
        this.Telemetry = new CarTelemetry(this);

    public interface ITelemetry {
        public void Calibrate();
        public bool SelfTest();
        public void ShowSponsor(string sponsorName);
        public void SetSpeed(decimal amount, string unitsString);
    }

    private class CarTelemetry : ITelemetry {
        private RemoteControlCar parentCar;
        internal CarTelemetry(RemoteControlCar parentCar) =>
            this.parentCar = parentCar;

        public void Calibrate()
        {

        }

        public bool SelfTest() =>
            true;


        public void ShowSponsor(string sponsorName) =>
            parentCar.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            parentCar.SetSpeed(new Speed(amount, speedUnits));
        }

    }

    public string GetSpeed() =>
        currentSpeed.ToString();

    private void SetSponsor(string sponsorName) =>
        CurrentSponsor = sponsorName;

    protected void SetSpeed(Speed speed) =>
        currentSpeed = speed;

}