using System;
using System.Collections.Generic;
using System.Reflection;

public class SpaceAge
{
    private static readonly Dictionary<string,double> ORBITAL_PERIODS = new(){
        ["Mercury"] = 0.2408467,
        ["Venus"] = 0.61519726,
        ["Earth"] = 1,
        ["Mars"] = 1.8808158,
        ["Jupiter"] = 11.862615,
        ["Saturn"] = 29.447498,
        ["Uranus"] = 84.016846,
        ["Neptune"] = 164.79132
    };
    private const double SECONDS_IN_YEAR = 31_557_600;
    private double _ageInEarthYears;

    public SpaceAge(int seconds) =>
        _ageInEarthYears = seconds / SECONDS_IN_YEAR;

    public double OnEarth() => _ageInEarthYears;

    public double OnMercury() {
        MethodBase method = MethodBase.GetCurrentMethod();
        string planet = method.Name[2..];
        return AgeOnPlanet(planet);
    }

    public double OnVenus() => AgeOnPlanet("Venus");

    public double OnMars() => AgeOnPlanet("Mars");

    public double OnJupiter() => AgeOnPlanet("Jupiter");

    public double OnSaturn() => AgeOnPlanet("Saturn");

    public double OnUranus() => AgeOnPlanet("Uranus");

    public double OnNeptune() => AgeOnPlanet("Neptune");

    public double AgeOnPlanet(string planet) =>
        _ageInEarthYears / ORBITAL_PERIODS[planet];
}