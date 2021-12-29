class Map
{
    public void road() { }
}

class AutoRoad: Map
{
    new public void road() 
    {
        Console.WriteLine("Маршрут для авто построен"); }
}

class WalkingRoad: Map
{
    new public void road()
    {
        Console.WriteLine("Маршрут для пешехода построен");
    }
}

class BusRoad : Map
{
    new public void road()
    {
        Console.WriteLine("Маршрут для общественного транспорта построен");
    }
}

class AttractionsRoad : Map
{
    new public void road()
    {
        Console.WriteLine("Маршрут для осмотра достопримечательностей построен");
    }
}

class Context
{
    string type_road;
    public Context(string type_road)
    {
        this.type_road = type_road;
    }

    public void search_road()
    {
        if (type_road == "авто") { AutoRoad way = new AutoRoad(); way.road(); }
        else if (type_road == "пешеход") { WalkingRoad way = new WalkingRoad(); way.road(); }
        else if (type_road == "автобус") { BusRoad way = new BusRoad(); way.road(); }
        else if (type_road == "достопримечательность") { AttractionsRoad way = new AttractionsRoad(); way.road(); }
        else Console.WriteLine("Невозможно найти маршрут");
    }
}

class Program
{
    static void Main(string[] str)
    {
        Context context_1 = new Context("пешеход");
        Context context_2 = new Context("автобус");

        context_1.search_road();
        context_2.search_road();
    }
}