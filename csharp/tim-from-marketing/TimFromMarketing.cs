using System;

static class Badge
{
    private const string DefaultDepartment = "owner";

    public static string Print(int? id, string name, string? department)
    {
        string idText = id == null ? "" : $"[{id}] - ";
        department = (department ?? DefaultDepartment).ToUpperInvariant();
        
        return $"{idText}{name} - {department}";
    }
}
