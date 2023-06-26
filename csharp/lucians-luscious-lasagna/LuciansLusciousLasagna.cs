class Lasagna
{
    private readonly int EXPECTED_MINUTES_IN_OVEN = 40;
    private readonly int TIME_PER_LAYER = 2;

    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() {
        return EXPECTED_MINUTES_IN_OVEN;
    }

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int currentMinutes) {
        return EXPECTED_MINUTES_IN_OVEN - currentMinutes;
    }

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int numLayers) {
        return numLayers * TIME_PER_LAYER;
    }

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int numLayers, int timeInOven) {
        return PreparationTimeInMinutes(numLayers) + timeInOven;
    }
}
