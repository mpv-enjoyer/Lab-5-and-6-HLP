string? input = " ";
SystemEmployee systemEmployee = new();
Console.WriteLine("add");
Console.WriteLine("break [ID] [minutes]");
Console.WriteLine("work [ID] [hours]");
Console.WriteLine("print");
Console.WriteLine("exit");
while (true)
{
    Console.Write("> ");
    input = Console.ReadLine();
    if (input == null || input == "exit") break;
    string[] split = input.Split();
    string command = split[0];
    int argument1 = split.Length > 1 ? int.Parse(split[1]) : 0;
    int argument2 = split.Length > 2 ? int.Parse(split[2]) : 0;
    switch (command)
    {
        case "add":
            Console.WriteLine(systemEmployee.AddEmployee());
            break;
        case "break":
            systemEmployee.BreakFor(argument1, argument2);
            break;
        case "work":
            systemEmployee.WorkFor(argument1, argument2);
            break;
        case "print":
            systemEmployee.Print(argument1);
            break;
        case "exit":
            Console.WriteLine("bye");
            return;
    }
}
interface IEmployee
{
    void Work(int hours);
    void TakeBreak(int minutes);
}
class Employee
{
    int MinutesWorked;
    int MinutesRested;
    public delegate void BreakTakenEventHandler(int minutes);
    public delegate void WorkPerformedEventHandler(int hours);
    public event WorkPerformedEventHandler? WorkPerformed;
    public event BreakTakenEventHandler? BreakTaken;
    public void Work(int hours)
    {
        MinutesWorked += hours * 60;
        WorkPerformed?.Invoke(hours);
    }
    public void TakeBreak(int minutes)
    {
        MinutesRested += minutes;
        BreakTaken?.Invoke(minutes);
    }
    public void Print()
    {
        Console.WriteLine($"Employee: {MinutesRested} minutes rested, {MinutesWorked} minutes worked.");
    }
}
class SystemEmployee
{
    List<Employee> employees = new();
    private void PrintBreak(int minutes, int ID)
    {
        Console.WriteLine($"break for {minutes} minutes for {ID}.");
    }
    private void PrintWorked(int hours, int ID)
    {
        Console.WriteLine($"worked for {hours} hours for {ID}.");
    }
    public SystemEmployee()
    {
        
    }
    public int AddEmployee()
    {
        int count = employees.Count;
        Employee employee = new();
        employee.WorkPerformed += s => PrintWorked(s, count);
        employee.BreakTaken += s => PrintBreak(s, count);
        employees.Add(employee);
        return employees.Count - 1;
    }
    public void BreakFor(int id, int minutes)
    {
        employees[id].TakeBreak(minutes);
    }
    public void WorkFor(int id, int hours)
    {
        employees[id].Work(hours);
    }
    public void Print(int id)
    {
        employees[id].Print();
    }
}