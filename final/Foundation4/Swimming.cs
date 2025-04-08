public class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        // Convert meters to miles: (laps * 50) meters = X meters = X / 1000 km = X / 1000 * 0.62 miles
        return laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();

    public override string GetSummary()
    {
        return $"{GetDate()} Swimming ({GetMinutes()} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
