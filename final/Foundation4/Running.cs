public class Running : Activity
{
    private double distance;

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / distance;

    public override string GetSummary()
    {
        return $"{GetDate()} Running ({GetMinutes()} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
