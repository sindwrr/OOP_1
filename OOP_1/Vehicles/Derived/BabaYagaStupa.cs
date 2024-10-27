namespace OOP_1.Vehicles.Derived;

// класс для ступы Бабы Яги
public class BabaYagaStupa(string? name) : AirVehicle(name, 50)
{
    protected override double CalculateAcceleration(double distance)
    {
        return 1 / distance + 5;
    }
}
