using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> _highScores;

    public HighScores(List<int> list) =>
        _highScores = list;

    public List<int> Scores() =>
        new List<int>(_highScores);

    public int Latest() =>
        _highScores.Last();

    public int PersonalBest() =>
        _highScores.Max();

    public List<int> PersonalTopThree() =>
        (from score in _highScores
        orderby score descending
        select score).Take(3).ToList();
}