namespace OOP_1.Vehicles.Derived;

// класс для кареты-тыквы
public class KaretaTykva(string? name) : GroundVehicle(name, 10.0, 300)
{
    protected override double CalculateRestTime(int index)
    {
        return double.Exp(index + 1);
    }
}
