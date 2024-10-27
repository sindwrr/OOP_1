using OOP_1.Race;
using OOP_1.Vehicles;
using OOP_1.Vehicles.Derived;

Console.WriteLine("==== Симулятор гонок 3000 ====");

// ввод дистанции
double distance;
while (true)
{
    Console.Write("\nВведите дистанцию забега (в метрах): ");
    if (double.TryParse(Console.ReadLine(), out distance) && distance > 0) break;
    Console.WriteLine("Неверный ввод, попробуйте снова.");
}

// ввод типа гонки
Console.WriteLine("\nВыберите тип гонки:");
Console.WriteLine("\t1 - Общая");
Console.WriteLine("\t2 - По земле");
Console.WriteLine("\t3 - В воздухе");

var raceType = 0;
while (!int.TryParse(Console.ReadLine(), out raceType) || raceType < 1 || raceType > 3)
{
    Console.WriteLine("Неверный ввод, попробуйте снова (1 - Общая, 2 - По земле, 3 - В воздухе)");
}

RaceType type = raceType switch
{
    1 => RaceType.General,
    2 => RaceType.Ground,
    3 => RaceType.Air,
    _ => throw new ArgumentOutOfRangeException()
};

// ввод погоды
Console.WriteLine("\nВыберите погоду:");
Console.WriteLine("\t1 - Ясно");
Console.WriteLine("\t2 - Ветер");
Console.WriteLine("\t3 - Дождь");
Console.WriteLine("\t4 - Снег");
Console.WriteLine("\t5 - Туман");

Weather weather;
while (true)
    if (int.TryParse(Console.ReadLine(), out var weatherType))
    {
        switch (weatherType)
        {
            case 1:
                weather = Weather.Sunny;
                break;
            case 2:
                weather = Weather.Windy;
                break;
            case 3:
                weather = Weather.Rainy;
                break;
            case 4:
                weather = Weather.Snowy;
                break;
            case 5:
                weather = Weather.Foggy;
                break;
            default:
                Console.WriteLine("Неверный тип гонки, попробуйте еще раз.");
                continue;
        }

        break;
    }
    else
    {
        Console.WriteLine("Неверный ввод, попробуйте снова.");
    }

var race = new Race(distance, type, weather);
var suitableVehicles = type switch
{
    RaceType.General => new Dictionary<int, string>
    {
        { 1, "Ковер-самолет" },
        { 2, "Избушка на курьих ножках" },
        { 3, "Летучий корабль" },
        { 4, "Сапоги-скороходы" },
        { 5, "Карета-тыква" },
        { 6, "Кентавр" },
        { 7, "Метла" },
        { 8, "Ступа Бабы Яги" }
    },
    RaceType.Ground => new Dictionary<int, string>
    {
        { 1, "Избушка на курьих ножках" },
        { 2, "Сапоги-скороходы" },
        { 3, "Карета-тыква" },
        { 4, "Кентавр" }
    },
    RaceType.Air => new Dictionary<int, string>
    {
        { 1, "Ковер-самолет" },
        { 2, "Летучий корабль" },
        { 3, "Метла" },
        { 4, "Ступа Бабы Яги" }
    },
    _ => new Dictionary<int, string>()
};

// выбор транспортных средств (ТС) и ввод их имен
Console.WriteLine("\nВыберите транспортные средства для участия в гонке (введите '0' для завершения):");
foreach (var vehicle in suitableVehicles)
{
    Console.WriteLine($"\t{vehicle.Key} - {vehicle.Value}");
}

while (true)
{
    Console.Write("\nВыберите транспортное средство (введите '0' для завершения): ");
    if (int.TryParse(Console.ReadLine(), out var vehicleChoice) && vehicleChoice == 0)
        break;

    if (suitableVehicles.TryGetValue(vehicleChoice, value: out var suitableVehicle))
    {
        Console.Write("Введите имя для транспортного средства: ");
        var vehicleName = Console.ReadLine();

        try
        {
            Vehicle vehicle = vehicleChoice switch
            {
                1 => type switch
                {
                    RaceType.General => new KoverSamolet(vehicleName),
                    RaceType.Ground => new Izbushka(vehicleName),
                    RaceType.Air => new KoverSamolet(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                2 => type switch
                {
                    RaceType.General => new Izbushka(vehicleName),
                    RaceType.Ground => new SapogiSkorokhody(vehicleName),
                    RaceType.Air => new LetuchiKorabl(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                3 => type switch
                {
                    RaceType.General => new LetuchiKorabl(vehicleName),
                    RaceType.Ground => new KaretaTykva(vehicleName),
                    RaceType.Air => new Metla(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                4 => type switch
                {
                    RaceType.General => new SapogiSkorokhody(vehicleName),
                    RaceType.Ground => new Kentavr(vehicleName),
                    RaceType.Air => new BabaYagaStupa(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                5 => type switch
                {
                    RaceType.General => new KaretaTykva(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                6 => type switch
                {
                    RaceType.General => new Kentavr(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                7 => type switch
                {
                    RaceType.General => new Metla(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                8 => type switch
                {
                    RaceType.General => new BabaYagaStupa(vehicleName),
                    _ => throw new InvalidOperationException("Неверный выбор.")
                },
                _ => throw new InvalidOperationException("Неверный выбор.")
            };

            race.RegisterVehicle(vehicle);
            Console.WriteLine($"{vehicleName} ({suitableVehicle}) добавлено.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else
    {
        Console.WriteLine("Неверный выбор, попробуйте снова.");
    }
}

// начало гонки
Console.WriteLine("\nНачать гонку? (y/n)");
while (true)
{
    var ans = Console.ReadLine();
    if (ans?.ToLower() == "y")
    {
        Console.WriteLine("\n3 ...");
        Thread.Sleep(1000);
        Console.WriteLine("2 ..");
        Thread.Sleep(1000);
        Console.WriteLine("1 .");
        Thread.Sleep(1000);
        try
        {
            race.StartRace();
            Console.WriteLine("Гонка началась!");
            Thread.Sleep(1000);
            Console.WriteLine("\nГонка окончена!");
            race.PrintResults();
            break;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            break;
        }
    }

    if (ans?.ToLower() == "n")
    {
        Console.WriteLine("Ну и пожалуйста...");
        break;
    }

    Console.WriteLine("Неверный ввод, повторите еще раз.");
}

Console.WriteLine("\n==== Работа симулятора окончена. Спасибо за использование! :) ====");
