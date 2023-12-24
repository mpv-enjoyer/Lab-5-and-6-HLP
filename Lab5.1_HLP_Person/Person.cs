return;

public class Person
{
    public string Name { get; set; }
    int age;
    public int Age
    {
        get { return age; }
        set { if (value < 0) value = 0; age = value; }
    }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public static Person RandomPerson()
    {
        Person[] random = { new Person("person name 1", 1),
            new Person("person name 2", 2),
            new Person("person name 3", 3),
            new Person("person name 4", 4),
            new Person("person name 5", 5)};
        int index = Rng.Next(0, 4);
        return random[index];
    }
    public virtual void Print()
    {
        Console.WriteLine($"Person {Name}, Age: {Age}");
    }
    public virtual Person Clone()
    {
        return new Person(Name, Age);
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != typeof(Person))
        {
            return false;
        }
        return ((Person)obj).Age == Age && ((Person)obj).Name == Name;
    }
    public override string ToString()
    {
        return "Person " + Name + ", Age: " + Age;
    }
    public override int GetHashCode()
    {
        return Age + 1000;
    }
}