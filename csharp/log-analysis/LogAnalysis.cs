using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string logMessage, string startAfter) =>
        SubstringBetween(logMessage, startAfter);

    public static string SubstringBetween(this string logMessage, string startAfter, string endBefore = null) {
        int startIndex = logMessage.IndexOf(startAfter) + startAfter.Length;
        int endIndex = endBefore is null ? logMessage.Length : logMessage.IndexOf(endBefore);
        return logMessage.Substring(startIndex, endIndex-startIndex);
    }
    
    public static string Message(this string str) =>
        SubstringAfter(str, ": ");

    public static string LogLevel(this string str) =>
        SubstringBetween(str, "[", "]");
}