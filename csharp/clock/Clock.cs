using System;

public class Clock
{
    private readonly int hours, minutes;

    public Clock(int hours, int minutes) {
        this.minutes = Mod(minutes, MINUTES_PER_HOUR);
        this.hours = Mod(hours + (int)Math.Floor((double)minutes / MINUTES_PER_HOUR), HOURS_PER_DAY);
    }

    public Clock Add(int minutesToAdd) =>
        new Clock(this.hours, this.minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) =>
        Add(0 - minutesToSubtract);

    public override string ToString() =>
        $"{hours:00}:{minutes:00}";

    public override bool Equals(object obj) {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return (this.hours) == ((Clock)obj).hours &&
               (this.minutes) == ((Clock)obj).minutes;
    }

    public override int GetHashCode() =>
        this.hours.GetHashCode() ^ this.minutes.GetHashCode();
    
    public static bool operator == (Clock c1, Clock c2) {
        if ((object)c1 == null)
            return (object)c2 == null;

        return c1.Equals(c2);
    }

    public static bool operator != (Clock c1, Clock c2) =>
        !(c1 == c2);

    private int Mod(int v, int m) =>
        (v % m + m) % m;

    #region Fixed values
    private const int MINUTES_PER_HOUR = 60;
    private const int HOURS_PER_DAY = 24;
    #endregion
}
