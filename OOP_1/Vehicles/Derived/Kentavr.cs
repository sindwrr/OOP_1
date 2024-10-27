namespace OOP_1.Vehicles.Derived;

// класс для кентавра
public class Kentavr(string? name) : GroundVehicle(name, 30.0, 100)
{
    protected override double CalculateRestTime(int index)
    {
        return 0.5 * index * index;
    }
}
