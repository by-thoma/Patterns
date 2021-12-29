public abstract class AutoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostBase { get; set; }
    public abstract double GetCost();
    public override string ToString()
    {
        string s = String.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
        Name, Description, GetCost());
        return s;
    }
}
class Ferrari : AutoBase
{
    public Ferrari(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }
    public override double GetCost()
    {
        return CostBase * 3.21;
    }
}
class Renault : AutoBase
{
    public Renault(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }
    public override double GetCost()
    {
        return CostBase * 1.18;
    }
}
class DecoratorOptions : AutoBase
{
    public AutoBase AutoProperty { protected get; set; }
    public string Title { get; set; }
    public DecoratorOptions(AutoBase au, string tit)
    {
        AutoProperty = au;
        Title = tit;
    }
    public override double GetCost() { return CostBase; }
}
class MediaNAV : DecoratorOptions
{
    public MediaNAV(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Современный";
        Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 15.99;
    }
}

class SystemSecurity : DecoratorOptions
{
    public SystemSecurity(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Повышенной безопасности";
        Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP -система динамической стабилизации автомобиля";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 20.99;
    }
}

class Player: DecoratorOptions //добавлен новый функционал
{
    public Player(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Встроенный плеер";
        Description = p.Description + ". " + this.Title + ". Система со встроенным голосовым помочником и Spotify";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 10.99;
    }
}

class Signal : DecoratorOptions 
{
    public Signal(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Новое поколение сигнализаций";
        Description = p.Description + ". " + this.Title + ". Сигнальная система с подачей сигнала в мобильное устройство";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 25.99;
    }
}


class Program
{
    private static void Print(AutoBase av)
    {
        Console.WriteLine(av.ToString());
    }
    static void Main(string[] str)
    {
        Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
        Print(reno);
        AutoBase myreno = new MediaNAV(reno, "Навигация");
        Print(myreno);
        AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"),
        "Безопасность");
        Print(newmyReno);
    }
}
