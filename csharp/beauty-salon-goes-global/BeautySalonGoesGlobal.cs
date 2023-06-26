using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{

    public static DateTime ShowLocalTime(DateTime dtUtc) =>
        dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) =>
        TimeZoneInfo.ConvertTimeToUtc(
            DateTime.Parse(appointmentDateDescription),
            GetLocationInfo(location).timeZoneInfo
        );

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        appointment.Subtract(alertOffsets[alertLevel]);

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) 
    {
        TimeZoneInfo tz = GetLocationInfo(location).timeZoneInfo;

        return tz.IsDaylightSavingTime(dt) !=
                tz.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try {
            return DateTime.Parse(dtStr, GetLocationInfo(location).cultureInfo);
        } catch (FormatException e) {
            return DateTime.MinValue;
        }
    }

    #region Helper functions
    private static LocationInfo GetLocationInfo(Location l) {
        string[] locationInfoIds;

        locationInfoIds = l switch {
            Location.NewYork => new string[] {"America/New_York", "en-US"},
            Location.London => new string[] {"Europe/London", "en-GB"},
            Location.Paris => new string[] {"Europe/Paris", "fr-FR"}
        };

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            TimeZoneInfo.TryConvertIanaIdToWindowsId(locationInfoIds[0], out locationInfoIds[0]);

        return new LocationInfo(TimeZoneInfo.FindSystemTimeZoneById(locationInfoIds[0]),
                    CultureInfo.GetCultureInfo(locationInfoIds[1]));
    }
    #endregion

    #region Structs
    private struct LocationInfo {
        internal LocationInfo(TimeZoneInfo ti, CultureInfo ci) {
            this.timeZoneInfo = ti;
            this.cultureInfo = ci;
        }

        internal TimeZoneInfo timeZoneInfo;
        internal CultureInfo cultureInfo;
    }
    #endregion

    #region Fixed values
    private static readonly ReadOnlyDictionary<AlertLevel,TimeSpan> alertOffsets =
        new ReadOnlyDictionary<AlertLevel,TimeSpan>(new Dictionary<AlertLevel,TimeSpan>() {
        [AlertLevel.Early] = new TimeSpan(days: 1,0,0,0),
        [AlertLevel.Standard] = new TimeSpan(hours: 1, minutes: 45, 0),
        [AlertLevel.Late] = new TimeSpan(0, minutes: 30, 0)
    });
    #endregion

}
