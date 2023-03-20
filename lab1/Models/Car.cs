
using lab1.Validators;


namespace lab1.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public double Price { get; set; }
    
    [DateInPast]
    public DateTime ProductionDate { get; set; }
    public string Type { get; set; } = string.Empty;

    private static List<Car> _cars = new List<Car> { };
    public static List<Car> GetCars() => _cars;
}
