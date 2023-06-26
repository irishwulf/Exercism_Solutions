using System;
using System.Text.RegularExpressions;

static class LogLine
{
    private static Regex _rx = new Regex(@"^\[(?<log_level>[^\]]*)\]: (?<message>.*)$");

    public static string Message(string logLine) =>
        _rx.Match(logLine).Groups["message"].Value.Trim();

    public static string LogLevel(string logLine) =>
        _rx.Match(logLine).Groups["log_level"].Value.ToLower();

    public static string Reformat(string logLine) =>
        $"{Message(logLine)} ({LogLevel(logLine)})";
}
