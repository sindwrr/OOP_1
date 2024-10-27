namespace OOP_1.Vehicles;

// абстрактный класс для наземных ТС
public abstract class GroundVehicle(string? name, double velocity, double runtime) : Vehicle(name, velocity)
{
    // вычисление времени отдыха в зависимости от номера остановки
    protected abstract double CalculateRestTime(int index);

    public override double CalculateTime(double distance)
    {
        double totalTime = 0;
        var remainingDistance = distance;
        var restCount = 0;

        while (remainingDistance > 0)
        {
            // Минимальное расстояние на одном промежутке времени
            var travelDistance = Math.Min(Velocity * WeatherFactor * runtime, remainingDistance);

            // Время, чтобы пройти часть дистанции
            totalTime += travelDistance / (Velocity * WeatherFactor);
            remainingDistance -= travelDistance;

            if (!(remainingDistance > 0)) continue;
            restCount++;
            totalTime += CalculateRestTime(restCount); // Время на отдых
        }

        return totalTime;
    }
}
