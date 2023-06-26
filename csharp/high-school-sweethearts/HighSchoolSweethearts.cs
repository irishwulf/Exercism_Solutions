using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    #region fixed values
    private const int SingleLineWidth = 61;
    private const int BannerWidth = 29;
    private const string BannerTop = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
";
    private const string BannerBottom = @"
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    private static readonly CultureInfo GermanCultureInfo = new CultureInfo("de-DE");
    #endregion
    
    public static string DisplaySingleLine(string studentA, string studentB) {
        int padding = (SingleLineWidth - 3) / 2;
        return $"{studentA.PadLeft(padding)} ♡ {studentB.PadRight(padding)}";
    }

    public static string DisplayBanner(string studentA, string studentB) {
        int padding = (BannerWidth - 9) / 2;
        string bannerMiddle = $"**{studentA.Trim().PadLeft(padding)}  +  {studentB.Trim().PadRight(padding)}**";
        return BannerTop + bannerMiddle + BannerBottom;
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) =>
        String.Format(GermanCultureInfo, "{0} and {1} have been dating since {2:d} - that's {3:n2} hours",
            studentA, studentB, start, hours);
}
