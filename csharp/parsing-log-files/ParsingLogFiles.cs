using System;
using System.Text.RegularExpressions;

public class LogParser
{
    #region fixed values
    private enum LogLevels {
        TRC,
        DBG,
        INF,
        WRN,
        ERR,
        FTL
    }
    private static Regex _rxLogLevel = new Regex(@"^\[(?<log_level>[^\]]*)\] (?<message>.*)$");
    private static Regex _rxDelimiter = new Regex(@"<[\^\*=-]+>");
    private static Regex _rxQuotedPassword = new Regex(@"(?im)"".*password.*""");
    private static Regex _rxEndOfLine = new Regex(@"end-of-line\d*");
    private static Regex _rxWeakPassword = new Regex(@"(?i)(?<password>\bpassword\w+)");
    private const string StrongPasswordPrefix = "--------";
    #endregion

    public bool IsValidLine(string text) =>
        Enum.IsDefined(typeof(LogLevels), _rxLogLevel.Match(text).Groups["log_level"].Value);

    public string[] SplitLogLine(string text) =>
        _rxDelimiter.Split(text);

    public int CountQuotedPasswords(string lines) =>
        _rxQuotedPassword.Count(lines);

    public string RemoveEndOfLineText(string line) =>
        _rxEndOfLine.Replace(line,"");

    public string[] ListLinesWithPasswords(string[] lines) {
        string[] output = new string[lines.Length];
        Match isWeakPassword;

        for (int i = 0; i < lines.Length; i++) {
            isWeakPassword = _rxWeakPassword.Match(lines[i]);
            if (isWeakPassword.Success) {
                output[i] = $"{isWeakPassword.Groups["password"]}: {lines[i]}";
            } else {
                output[i] = $"{StrongPasswordPrefix}: {lines[i]}";
            }
        }
        return output;
    }

}
