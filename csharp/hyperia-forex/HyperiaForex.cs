using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator == (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return a.amount == b.amount;
    }
    public static bool operator != (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return a.amount != b.amount;
    }
    public static bool operator > (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return a.amount > b.amount;
    }
    public static bool operator < (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return a.amount < b.amount;
    }
    public static CurrencyAmount operator + (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }
    public static CurrencyAmount operator - (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }
    public static CurrencyAmount operator * (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return new CurrencyAmount(a.amount * b.amount, a.currency);
    }
    public static CurrencyAmount operator / (CurrencyAmount a, CurrencyAmount b) {
        ValidateSameCurrency(a,b);
        return new CurrencyAmount(a.amount / b.amount, a.currency);
    }
    public static explicit operator double(CurrencyAmount a) =>
        (double)a.amount;

    public static implicit operator decimal(CurrencyAmount a) =>
        (decimal)a.amount;

    private static void ValidateSameCurrency(CurrencyAmount a, CurrencyAmount b) {
        if (a.currency != b.currency) throw new ArgumentException();
    }
}
