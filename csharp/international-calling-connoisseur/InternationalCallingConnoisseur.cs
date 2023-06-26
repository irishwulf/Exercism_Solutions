using System;
using System.Collections.Generic;

public static class DialingCodes
{
    #region fixed values
    private static Dictionary<int, string> _countryCodes = new Dictionary<int, string> {
        [1] = "United States of America",
        [55] = "Brazil",
        [91] = "India"
    };
    #endregion

    public static Dictionary<int, string> GetEmptyDictionary() =>
        new();

    public static Dictionary<int, string> GetExistingDictionary() =>
        new(_countryCodes);

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) =>
        new() { [countryCode] = countryName };

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName) {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode) ? existingDictionary[countryCode] : "";

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
            if (existingDictionary.ContainsKey(countryCode))
                existingDictionary[countryCode] = countryName;
            return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestName = "";
        foreach (string name in existingDictionary.Values) {
            if (name.Length > longestName.Length)
                longestName = name;
        }
        return longestName;
    }
}