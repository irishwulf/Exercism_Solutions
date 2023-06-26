using System;

class WeighingMachine
{
    public int Precision { get; }
    private double _weight;
    public double Weight {
        get => _weight;
        set {
            if (value >= 0)
                _weight = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
    public string DisplayWeight {
        get => (Weight - TareAdjustment).ToString($"f{Precision}") + " kg";
    }
    public double TareAdjustment { get; set; } = _defaultTare;

    public WeighingMachine(int precision) =>
        this.Precision = precision;

    #region fixed values
        private const double _defaultTare = 5;
    #endregion
}
