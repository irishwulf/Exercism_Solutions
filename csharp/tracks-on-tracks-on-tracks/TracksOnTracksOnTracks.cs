using System;
using System.Collections.Generic;

public static class Languages
{
    #region fixed values
    private static List<string> _existingLanguages =  new List<string>() { "C#", "Clojure", "Elm" };
    private static string _excitingLanguage = "C#";
    #endregion

    public static List<string> NewList() =>
        new List<string>();

    public static List<string> GetExistingLanguages() =>
        _existingLanguages;

    public static List<string> AddLanguage(List<string> languages, string language) {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) =>
        languages.Count;

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages) =>
        (languages.Count > 0 && languages[0] == _excitingLanguage) ||
        ((languages.Count == 2 || languages.Count == 3 ) &&
            languages[1] == _excitingLanguage
        );

    public static List<string> RemoveLanguage(List<string> languages, string language) {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        foreach (string item in languages) {
            if (languages.IndexOf(item) != languages.LastIndexOf(item))
                return false;
        }
        return true;
    }
}