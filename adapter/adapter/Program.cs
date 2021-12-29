interface ISensor
{
    public int get_temp();
}

public class FarenheitSensor
{
    public int get_Fahr_temp()
    {
        return 5;
    }
}

public class Adapter: ISensor
{
    FarenheitSensor adaptee;

    public Adapter(FarenheitSensor adaptee)
    {
        this.adaptee = adaptee;
    }

    public int get_temp()
    {
        return (this.adaptee.get_Fahr_temp() - 32) * 5 / 9;
    }


}

class Program
{
    static void Main(string[] args)
    {
        FarenheitSensor fahr_sensor = new FarenheitSensor();
        Console.WriteLine($"Температура в Фаренгейтах\n{fahr_sensor.get_Fahr_temp()}");

        Adapter adapter = new Adapter(fahr_sensor);
        Console.WriteLine($"Температура в Цельсиях\n{adapter.get_temp()}");

    }
}

