public class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed() => speed;

    public override double GetDistance() => (speed * GetMinutes()) / 60;

    public override double GetPace() => 60 / speed;

    public override string GetSummary()
    {
        return $"{GetDate()} Cycling ({GetMinutes()} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
