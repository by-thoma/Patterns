class Cook_pizza
{
    Preparing prep;
    Slicing slice;
    Baking bake;

    public Cook_pizza()
    {
        prep = new Preparing();
        slice = new Slicing();
        bake = new Baking();
    }

    public string start()
    {
        string process = "";
        process += prep.wash() + "\n";
        process += prep.peel() + "\n";
        process += slice.slice() + "\n";
        process += bake.preheat() + "\n";
        process += bake.bake() + "\n";
        return process;

    }
}

class Preparing
{ 
    public string wash()
    {
        return "Помыть продукты";
    }

    public string peel()
    {
        return "Очистить от кожуры";
    }
}

class Slicing
{
    public string slice()
    {
        return "Нарезать продукты";
    }
}

class Baking
{
    public string preheat()
    {
        return "Нагреть духовку";
    }

    public string bake()
    {
        return "Испечь блюдо";
    }
}

class Program
{
    static void Main(string[] str)
    {
        Cook_pizza cooking = new Cook_pizza();
        Console.WriteLine(cooking.start());
    }
}

