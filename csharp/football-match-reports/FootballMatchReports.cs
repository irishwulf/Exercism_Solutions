using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch {
        1 => "goalie",
        2 => "left back",
        3 => "center back",
        4 => "center back",
        5 => "right back",
        >= 6 and <= 8 => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => throw new ArgumentOutOfRangeException()
    };

    public static string AnalyzeOffField(object report) => report switch {
        int numSupporters => $"There are {numSupporters} supporters at the match.",
        string announce => announce,
        Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
        Incident incident => incident.GetDescription(),
        Manager manager => $"{manager.Name}{getClubText(manager.Club)}",
        _ => throw new ArgumentException()
    };

    private static string getClubText(string? club) =>
        club is null ? "" : $" ({club})";
}
