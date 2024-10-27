namespace OOP_1.Vehicles.Derived;

// класс для избушки на курьих ножках
public class Izbushka(string? name) : GroundVehicle(name, 25.0, 150)
{
    protected override double CalculateRestTime(int index)
    {
        return double.Log2(index);
    }
}
