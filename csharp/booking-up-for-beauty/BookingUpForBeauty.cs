using System;

static class Appointment
{
    private static DateTime _anniversaryDate = new DateTime(1999, 9, 15);

    public static DateTime Schedule(string appointmentDateDescription) =>
        DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) =>
        appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>
        appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;

    public static string Description(DateTime appointmentDate) =>
        $"You have an appointment on {appointmentDate.ToString()}.";

    public static DateTime AnniversaryDate() =>
        new DateTime(DateTime.Now.Year, _anniversaryDate.Month, _anniversaryDate.Day);
}
