StopLight stopLight = new();
stopLight.Loop();

class StopLight
{
    Action action;
    public StopLight() 
    {
        action = () => ShowRed();
        Console.ResetColor();
    }
    public void Loop()
    {
        while (true)
        {
            action.Invoke();
        }
    }
    void ShowRed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Red");
        Thread.Sleep(20 * 1000);
        action = () => ShowYellow();
    }
    void ShowYellow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Yellow");
        Thread.Sleep(5 * 1000);
        action = () => ShowGreen();
    }
    void ShowGreen()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Green");
        Thread.Sleep(15 * 1000);
        action = () => ShowRed();
    }
}