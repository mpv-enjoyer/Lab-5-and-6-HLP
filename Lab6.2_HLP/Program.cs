TaskManager taskManager = new();
Task firstTask = new();
Task secondTask = new();
firstTask.Name = "1st";
firstTask.Description = "High priority";
secondTask.Name = "2nd";
secondTask.Description = "Low priority";
taskManager.AddTask(firstTask);
taskManager.AddTask(secondTask);
new Notifier(taskManager);
Console.WriteLine("Press Enter to complete 2nd task");
Console.ReadLine();
taskManager.CompleteTask(secondTask);
Console.WriteLine("Press Enter to complete 1st task");
Console.ReadLine();
taskManager.CompleteTask(firstTask);

public delegate void CustomCallback(Task task);
public class Task
{
    public bool Completed;
    public string? Name;
    public string? Description;
}
class TaskManager
{
    CustomCallback? Callback;
    List<Task> _tasks = new();
    public void AddTask(Task task)
    {
        _tasks.Add(task);
    }
    public int TasksSize()
    {
        return _tasks.Count;
    }
    public void PrintTask(int index)
    {
        Console.WriteLine($"{_tasks[index].Name} ({_tasks[index].Description}) Completed: {_tasks[index].Completed}");
    }
    public void DeleteTask(int index)
    {
        _tasks.RemoveAt(index);
    }
    public void CompleteTask(Task task)
    {
        foreach (var item in _tasks)
        {
            item.Completed = true;
            Callback?.Invoke(task);
            return;
        }
        throw new Exception();
    }
    public void Subscribe(CustomCallback callback)
    {
        Callback += callback;
    }
}
class Notifier
{
    TaskManager _taskManager;
    public Notifier(TaskManager taskManager)
    {
        _taskManager = taskManager;
        _taskManager.Subscribe(TaskCompletedNotification);
    }
    public void TaskCompletedNotification(Task task)
    {
        Console.WriteLine($"{task.Name} ({task.Description}) process completed");
    }
}