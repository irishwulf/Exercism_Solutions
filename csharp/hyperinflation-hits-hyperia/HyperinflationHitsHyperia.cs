using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try {
            return checked(@base * multiplier).ToString();
        } catch (OverflowException) {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier) => (@base * multiplier) switch {
        float.PositiveInfinity => "*** Too Big ***",
        var result => result.ToString()
    };

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try {
            return (salaryBase * multiplier).ToString();
        } catch (OverflowException) {
            return "*** Much Too Big ***";
        }
    }
}
