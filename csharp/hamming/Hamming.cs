using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int distance = 0;
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException("Strands must be of equal length.");

        return firstStrand.Zip(secondStrand).Count(strand => strand.First != strand.Second);
    }
}