namespace OOP_1.Vehicles.Derived;

// класс для метлы
public class Metla(string? name) : AirVehicle(name, 70)
{
    protected override double CalculateAcceleration(double distance)
    {
        return distance * 0.01;
    }
}
