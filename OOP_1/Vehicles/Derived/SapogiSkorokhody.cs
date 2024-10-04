namespace OOP_1.Vehicles.Derived;

// класс для сапог-скороходов
public class SapogiSkorokhody(string? name) : GroundVehicle(name, 40.0, 200)
{
    protected override double CalculateRestTime(int index)
    {
        return index * 2;
    }
}
