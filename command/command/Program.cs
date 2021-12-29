abstract class Command
{
    protected ArithmeticUnit unit;
    protected double operand;
    public abstract void Execute();
    public abstract void UnExecute();
}

class ArithmeticUnit
{
    public double Register { get; private set; }
    public void Run(char operationCode, double operand)
    {
        switch (operationCode)
        {
            case '+':
                Register += operand;

                break;
            case '-':
                Register -= operand;

                break;
            case '*':
                Register *= operand;

                break;
            case '/':
                Register /= operand;

                break;

        }
    }
}

class ControlUnit
{
    private List<Command> commands = new List<Command>();
    private int current = 0;
    public void StoreCommand(Command command)
    {
        commands.Add(command);
    }
    public void ExecuteCommand()
    {
        commands[current].Execute();
        current++;
    }
    public void Undo()
    {
        commands[current - 1].UnExecute();
    }
    public void Redo()
    {
        commands[current - 1].Execute();
    }
}

class Add : Command
{
    public Add(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('+', operand);
    }
    public override void UnExecute()

    {
        unit.Run('-', operand);
    }
}

class Sub : Command
{
    public Sub(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('-', operand);
    }
    public override void UnExecute()

    {
        unit.Run('+', operand);
    }
}

class Mul : Command
{
    public Mul(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('*', operand);
    }
    public override void UnExecute()

    {
        unit.Run('/', operand);
    }
}

class Div : Command
{
    public Div(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('/', operand);
    }
    public override void UnExecute()

    {
        unit.Run('*', operand);
    }
}

class Calculator
{
    ArithmeticUnit arithmeticUnit;
    ControlUnit controlUnit;
    public Calculator()
    {
        arithmeticUnit = new ArithmeticUnit();
        controlUnit = new ControlUnit();
    }
    private double Run(Command command)
    {
        controlUnit.StoreCommand(command);
        controlUnit.ExecuteCommand();
        return arithmeticUnit.Register;
    }
    public double Add(double operand)
    {
        return Run(new Add(arithmeticUnit, operand));
    }
    public double Sub(double operand)
    {
        return Run(new Sub(arithmeticUnit, operand));
    }
    public double Mul(double operand)
    {
        return Run(new Mul(arithmeticUnit, operand));
    }
    public double Div(double operand)
    {
        return Run(new Div(arithmeticUnit, operand));
    }
}

class Program
{
    static void Main(string[] str)
    {
        var calculator = new Calculator();
        double result = 0;
        result = calculator.Add(5);
        Console.WriteLine(result);
        result = calculator.Add(4);
        Console.WriteLine(result);

        result = calculator.Add(3);
        Console.WriteLine(result);
    }
}