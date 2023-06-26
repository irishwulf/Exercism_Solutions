using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot : IComparable
{
    private List<Coord> corners = new();
    private double longestSide = 0;
    
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4) {
        List<Coord> coordinates = new() {c1, c2, c3, c4};
        double sideLength = 0;
        foreach (Coord newCoord in coordinates) {
            foreach (Coord existing in corners) {
                sideLength = GetSideLength(newCoord, existing);
                if (sideLength > longestSide)
                    longestSide = sideLength;
            }
            corners.Add(newCoord);
        }
    }

    private double GetSideLength(Coord c1, Coord c2) =>
        Math.Sqrt((c1.X - c2.X)^2 + (c1.Y - c2.Y)^2);

    public int CompareTo(object obj) {
        if (obj.GetType() != typeof(Plot))
            throw new InvalidOperationException();
        
        return this.longestSide.CompareTo(((Plot)obj).longestSide);
    }

    public override bool Equals(object obj) =>
        obj is Plot && this == (Plot) obj;

    public static bool operator == (Plot p1, Plot p2) =>
        p1.CompareTo(p2) == 0;

    public static bool operator != (Plot p1, Plot p2) =>
        p1.CompareTo(p2) != 0;
}


public class ClaimsHandler
{
    List<Plot> claims = new();
    Plot latest;

    public void StakeClaim(Plot plot)
    {
        latest = plot;
        claims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) =>
        claims.Contains(plot);

    public bool IsLastClaim(Plot plot) =>
        latest == plot;

    public Plot GetClaimWithLongestSide() =>
        claims.Max();
}
