using System;

public static class ResistorColor
{
    private static readonly string[] COLORS = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color) =>
        Array.IndexOf(COLORS, color);

    public static string[] Colors() =>
        COLORS;
}