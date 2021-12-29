abstract class CarFactory
{
    public abstract AbstractCar CreateCar();
    public abstract AbstractEngine CreateEngine();
}
abstract class AbstractCar
{
    public string Name { get; set; }
    public string Bodywork { get; set; }
    public abstract int MaxSpeed(AbstractEngine engine);

}
abstract class AbstractEngine
{
    public int max_speed { get; set; }
}
class AudiFactory : CarFactory
{
    AudiFactory() { }
    static Lazy<AudiFactory> myFactory = new Lazy<AudiFactory>(()=> new AudiFactory());
    public static AudiFactory myFactory
    {
        get
        {
        return myFactory.Value;
        }
    }
    public override AbstractCar CreateCar()
    {
        return new AudiCar("Ауди","Universal");
    }
    public override AbstractEngine CreateEngine()
    {
        return new FordEngine();
    }
}
class AudiCar : AbstractCar
{
    public AudiCar(string name, string bodywork)
    {
        Name = name;
        Bodywork = bodywork;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name + ". " + "Тип кузова " + Bodywork;

    }
}
class AudiEngine : AbstractEngine
{
    public AudiEngine()
    {
        max_speed = 250;
    }
}
class FordFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new FordCar("Форд", "Universal");
    }
    public override AbstractEngine CreateEngine()
    {
        return new FordEngine();
    }
}
class FordCar : AbstractCar
{
    public FordCar(string name, string bodywork)
    {
        Name = name;
        Bodywork= bodywork;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name + ". " + "Тип кузова " + Bodywork; ;

    }
}
class FordEngine : AbstractEngine
{
    public FordEngine()
    {
        max_speed = 220;
    }
}
class Client
{
    private AbstractCar abstractCar;
    private AbstractEngine abstractEngine;
    public Client(CarFactory car_factory)
    {
        abstractCar = car_factory.CreateCar();
        abstractEngine = car_factory.CreateEngine();
    }
    public int RunMaxSpeed()
    {
        return abstractCar.MaxSpeed(abstractEngine);
    }
    public override string ToString()
    {
        return abstractCar.ToString();
    }
}

class Program
{
    static void Main(string[] str)
    {
        CarFactory ford_car = new FordFactory();
        Client c1 = new Client(ford_car);
        Console.WriteLine("Максимальная скорость [{0}] составляет {1} км/час",
        c1.ToString(), c1.RunMaxSpeed());

        Audi
    }
}