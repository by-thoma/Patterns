abstract class Haircut
{
    public abstract void cut_top();
    public abstract void cut_back();
    public abstract void styling();

    //последовательность действия стрижек и уже определена:
    public void haircut()
    {
        this.cut_top();
        this.cut_back();
        this.styling();
    }
}

class Short_cut : Haircut
{
    public override void cut_top()
    {
        Console.WriteLine("Сделать челку длиной 5 см");
    }
    public override void cut_back()
    {
        Console.WriteLine("Отстричь волосы до верхней части шеи");
    }
    public override void styling()
    {
        Console.WriteLine("Уложить с помощью фена и расчески, создать объем");
    }
}

class Long_cut : Haircut
{
    public override void cut_top()
    {
        Console.WriteLine("Выровнять кончики");
    }
    public override void cut_back()
    {
        Console.WriteLine("Профилировать");
    }
    public override void styling()
    {
        Console.WriteLine("Уложить с помощью плойки");
    }
}

class Program
{
    static void Main(string[] str)
    {
        Short_cut short_cut = new Short_cut();
        Long_cut long_cut = new Long_cut();

        Console.WriteLine("короткая стрижка: ");
        short_cut.haircut();

        Console.WriteLine("длинная стрижка: ");
        long_cut.haircut();

    }
}