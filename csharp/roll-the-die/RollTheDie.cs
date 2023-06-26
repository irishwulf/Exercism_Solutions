using System;

public class Player
{
    private readonly int _dieSize = 18;
    private readonly double _maxSpellStrength = 100.0;
    private Random rand = new Random();

    public int RollDie() =>
        rand.Next(1, _dieSize + 1);

    public double GenerateSpellStrength() =>
        rand.NextDouble() * _maxSpellStrength;
}
