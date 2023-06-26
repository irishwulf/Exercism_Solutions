using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance) =>
        balance switch {
            <  0               => 3.213f,
            >= 0 and < 1000    => 0.5f,
            >= 1000 and < 5000 => 1.621f,
            >= 5000            => 2.475f
        };

    public static decimal Interest(decimal balance) =>
        balance * (decimal) InterestRate(balance) * 0.01m;

    public static decimal AnnualBalanceUpdate(decimal balance) =>
        balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance) {
            years++;
            balance = AnnualBalanceUpdate(balance);
        }
        return years;
    }
}
