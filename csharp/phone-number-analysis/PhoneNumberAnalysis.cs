using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) =>
        (
            IsNewYork: phoneNumber[0..3].Equals("212"),
            IsFake: phoneNumber[4..7].Equals("555"),
            LocalNumber: phoneNumber[8..]
        );

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) =>
        phoneNumberInfo.IsFake;
}
