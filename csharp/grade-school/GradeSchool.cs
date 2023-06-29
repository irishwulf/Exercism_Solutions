using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<string, int> _roster = new();

    public bool Add(string student, int grade) =>
        _roster.TryAdd(student, grade);

    public IEnumerable<string> Roster() =>
        _roster.
            OrderBy(e => e.Value).
            ThenBy(e => e.Key).
            Select(e => e.Key);

    public IEnumerable<string> Grade(int grade) =>
        _roster.
            Where(e => e.Value == grade).
            OrderBy(e => e.Key).
            Select(e => e.Key);
}