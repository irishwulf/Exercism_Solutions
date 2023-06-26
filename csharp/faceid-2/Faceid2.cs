using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(Object other) =>
        ReferenceEquals(this, other) ||
        Equals((FacialFeatures)other);

    public bool Equals(FacialFeatures other) =>
        this.EyeColor == other.EyeColor &&
        this.PhiltrumWidth == other.PhiltrumWidth;

  public override int GetHashCode() =>
    HashCode.Combine<string,decimal>(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(Object other) =>
        ReferenceEquals(this, other) ||
        Equals((Identity)other);

    public bool Equals(Identity other) =>
        this.Email.Equals(other.Email) &&
        this.FacialFeatures.Equals(other.FacialFeatures);

    public override Int32 GetHashCode() =>
        HashCode.Combine<string,FacialFeatures>(Email, FacialFeatures);
}

public class Authenticator
{
    #region fixed values
    private static readonly Identity _admin = new Identity(
        email: "admin@exerc.ism",
        facialFeatures: new FacialFeatures(eyeColor: "green", philtrumWidth: 0.9m)
    );
    #endregion

    private HashSet<Identity> registeredIdentities = new();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) =>
        identity.Equals(_admin);

    public bool Register(Identity identity) =>
        registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) {
        return registeredIdentities.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        identityA == identityB;
}
