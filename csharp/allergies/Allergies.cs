using System;
using System.Linq;

[Flags]
public enum Allergen
{
    None         = 0,
    Eggs         = 1 << 0,
    Peanuts      = 1 << 1,
    Shellfish    = 1 << 2,
    Strawberries = 1 << 3,
    Tomatoes     = 1 << 4,
    Chocolate    = 1 << 5,
    Pollen       = 1 << 6,
    Cats         = 1 << 7
}

public class Allergies
{
    private static readonly int _allAllergens = Enum.GetValues<Allergen>().Cast<int>().Sum();
    private Allergen myAllergens;

    public Allergies(int mask) =>
        myAllergens = (Allergen)(mask % (_allAllergens + 1));

    public bool IsAllergicTo(Allergen allergen) =>
        myAllergens.HasFlag(allergen);

    public Allergen[] List() =>
        myAllergens == Allergen.None ?
            new Allergen[0] :
            myAllergens.
                ToString().
                Split(',').
                Select(flag => (Allergen)Enum.Parse<Allergen>(flag.Trim())).
                ToArray();
}