namespace OOP_1.Vehicles;

// абстрактный класс для воздушных ТС
public abstract class AirVehicle(string? name, double velocity) : Vehicle(name, velocity)
{
    // вычисление ускорения в зависимости от дистанции
    protected abstract double CalculateAcceleration(double distance);

    public override double CalculateTime(double distance)
    {
        var acceleration = CalculateAcceleration(distance);
        return (-Velocity * WeatherFactor +
                double.Sqrt(Velocity * Velocity * WeatherFactor + 2 * acceleration * distance)) / acceleration;
    }
}
