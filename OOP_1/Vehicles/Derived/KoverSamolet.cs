namespace OOP_1.Vehicles.Derived;

// класс для ковра-самолета
public class KoverSamolet(string? name) : AirVehicle(name, 55)
{
    protected override double CalculateAcceleration(double distance)
    {
        return 0.000005 * distance * distance;
    }
}
