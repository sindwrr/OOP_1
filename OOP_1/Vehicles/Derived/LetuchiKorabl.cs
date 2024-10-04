namespace OOP_1.Vehicles.Derived;

// класс для летучего корабля
public class LetuchiKorabl(string? name) : AirVehicle(name, 50)
{
    protected override double CalculateAcceleration(double distance)
    {
        return double.Exp(1 / distance);
    }
}
