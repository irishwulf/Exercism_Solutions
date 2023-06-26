using System;

class BirdCount
{
    private static readonly int _busyDayThreshold = 5;
    private static readonly int[] lastWeeksBirds = {0, 2, 5, 3, 7, 8, 4};
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) =>
        this.birdsPerDay = birdsPerDay;

    public static int[] LastWeek() =>
        lastWeeksBirds;

    public int Today() =>
        birdsPerDay[^1];

    public void IncrementTodaysCount() =>
        birdsPerDay[^1]++;

    public bool HasDayWithoutBirds()
    {
        bool found = false;
        foreach(int dayCount in birdsPerDay) {
            found = found || dayCount == 0;
        }
        return found;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for(int i = 0; i < numberOfDays; i++) {
            count += birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays()
    {
        int count = 0;
        foreach (int dayCount in birdsPerDay) {
            if (dayCount >= _busyDayThreshold)
                count++;
        }
        return count;
    }
}
