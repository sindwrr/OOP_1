using OOP_1.Vehicles;

namespace OOP_1.Race;

// класс для гонки
public class Race(double distance, RaceType type, Weather weather)
{
    private readonly List<Vehicle?> _vehicles = []; // список участвующих ТС
    private readonly List<(string Name, double Time)> _results = []; // список с результатами

    // регистрация участника
    public void RegisterVehicle(Vehicle? vehicle)
    {
        if (vehicle == null) return;

        // если ТС не подходит для гонки, бросаем исключение
        switch (type)
        {
            case RaceType.Ground when vehicle is AirVehicle:
            case RaceType.Air when vehicle is GroundVehicle:
                throw new InvalidOperationException("Транспорт не подходит для данного типа гонки.");
            case RaceType.General:
                break;
        }

        // определяем погодный фактор для каждого типа ТС
        var weatherFactor = weather switch
        {
            Weather.Windy => vehicle is AirVehicle ? 0.5 : 0.8,
            Weather.Rainy => vehicle is AirVehicle ? 0.6 : 0.8,
            Weather.Snowy => vehicle is AirVehicle ? 0.9 : 0.5,
            Weather.Foggy => vehicle is AirVehicle ? 0.9 : 0.7,
            _ => 1.0
        };

        vehicle.WeatherFactor = weatherFactor;
        _vehicles.Add(vehicle);
    }

    // начало симуляции гонки
    public void StartRace()
    {
        // вычисляем результаты
        foreach (var t in _vehicles)
        {
            var currTime = t!.CalculateTime(distance);
            _results.Add((t.Name, currTime)!);
        }

        _results.Sort((x, y) => x.Time.CompareTo(y.Time));
    }

    // вывод инфы о победителе
    public void PrintResults()
    {
        for (int i = 0; i < _results.Count; i++)
        {
            Console.WriteLine("\n{0} место: {1}", i + 1, _results[i].Name);
            Console.WriteLine("Время: {0} с", double.Round(_results[i].Time, 3));
        }
    }
}
