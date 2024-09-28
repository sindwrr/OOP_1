namespace OOP_1.Vehicles;

// абстрактный класс для всех ТС
public abstract class Vehicle(string? name, double velocity)
{
    private double _weatherFactor; // число, отражающее влияние погоды на забег конкретного ТС
    public string? Name { get; } = name; // название ТС
    protected double Velocity { get; } = velocity; // скорость ТС

    public double WeatherFactor
    {
        get => _weatherFactor;
        set => _weatherFactor = value < 0 ? 0 : value > 1 ? 1 : value;
    }

    // вычисление общего времени забега
    public abstract double CalculateTime(double distance);
}
