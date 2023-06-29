using System;
using System.Linq;

public static class RotationalCipher
{
   public static string Rotate(string text, int shiftKey) =>
        new string(text.Select(c => RotateChar(c, shiftKey)).ToArray());

    private static char RotateChar(char c, int shiftKey) => c switch {
        >= 'a' and <= 'z' => (char)((c + shiftKey - 'a') % 26 + 'a'),
        >= 'A' and <= 'Z' => (char)((c + shiftKey - 'A') % 26 + 'A'),
        _ => c
    };
}