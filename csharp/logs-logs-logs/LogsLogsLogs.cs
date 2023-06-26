using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

enum LogLevel
{
    Trace   = 1,
    Debug   = 2,
    Info    = 4,
    Warning = 5,
    Error   = 6,
    Fatal   = 42,
    Unknown = 0
};

static class LogLine
{
    #region fixed values
    private static Dictionary<string,LogLevel> _logAbbreviations = new()
    {
        ["TRC"] = LogLevel.Trace,
        ["DBG"] = LogLevel.Debug,
        ["INF"] = LogLevel.Info,
        ["WRN"] = LogLevel.Warning,
        ["ERR"] = LogLevel.Error,
        ["FTL"] = LogLevel.Fatal
    };
    private static Regex _rxLogEntry = new Regex(@"^\[(?<log_level>[^\]]*)\]: (?<message>.*)$");
    #endregion

    public static LogLevel ParseLogLevel(string logLine)
    {
        string logAbbr = _rxLogEntry.Match(logLine).Groups["log_level"].Value.ToUpper();
        return _logAbbreviations.ContainsKey(logAbbr) ? _logAbbreviations[logAbbr] : LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) =>
        $"{(int)logLevel}:{message}";
}
