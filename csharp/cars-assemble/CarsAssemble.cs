using System;

static class AssemblyLine
{
    private static readonly int BASE_CARS_PER_HOUR = 221;

    public static double SuccessRate(int speed)
    {
        switch(speed) {
            case 0:
                return 0;
            case int n when (n >= 1 && n <= 4):
                return 1;
            case int n when (n >= 5 && n <= 8):
                return 0.9;
            case 9:
                return 0.8;
            case 10:
                return 0.77;
            default:
                return -1;
        }
    }
    
    public static double ProductionRatePerHour(int speed) =>
        BASE_CARS_PER_HOUR * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) =>
        (int) ProductionRatePerHour(speed) / 60;
}
