using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    private static readonly char[] _nucleotides = new[] { 'A', 'C', 'G', 'T' };
    public static IDictionary<char, int> Count(string sequence) {
        Dictionary <char, int> sequenceCount = _nucleotides.ToDictionary(c => c, c => 0);
        sequenceCount = sequence.Aggregate(
            sequenceCount,
            (dict, letter) => {
                if (_nucleotides.Contains(letter))
                    dict[letter]++;
                else throw new ArgumentException($"Invalid character '{letter}' in sequence '{sequence}'.");
                return dict;
            },
            dict => dict
        );

        return sequenceCount;
    }
}