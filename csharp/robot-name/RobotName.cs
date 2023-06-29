using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    private static HashSet<string> deployedNames = new();
    private Random rand = new Random();

    public string Name
    {
        get; private set;
    }

    public Robot()
    {
        Reset();
    }

    public void Reset()
    {
        Name = NewRandomName();
    }

    private string NewRandomName() {
        string newRandomName;
        char[] newNameBuilder = new char[5];

        do {
            newNameBuilder[0] = _alphaChars[rand.Next(_alphaChars.Length)];
            newNameBuilder[1] = _alphaChars[rand.Next(_alphaChars.Length)];
            newNameBuilder[2] = _numberChars[rand.Next(_numberChars.Length)];
            newNameBuilder[3] = _numberChars[rand.Next(_numberChars.Length)];
            newNameBuilder[4] = _numberChars[rand.Next(_numberChars.Length)];
            newRandomName = new String(newNameBuilder);
        } while (deployedNames.Contains(newRandomName));

        deployedNames.Add(newRandomName);
        return newRandomName;
    }

    #region Fixed values
    private static readonly char[] _alphaChars = Enumerable.Range('A', 'Z' - 'A' + 1).
                     Select(c => (char)c).ToArray();
    private static readonly char[] _numberChars = Enumerable.Range('0', '9' - '0' + 1).
                     Select(c => (char)c).ToArray();
    #endregion
}