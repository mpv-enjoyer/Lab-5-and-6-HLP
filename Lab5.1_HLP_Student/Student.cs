using System.Xml.Linq;
using System;

return;

public class Student : Person
{
    int course;
    public int Course
    {
        get { return course; }
        set { if (value < 1 || value > 6) value = 1; course = value; }
    }
    public Student(string name, int age) : base(name, age)
    {
        course = 0;
    }
    public static Student RandomStudent()
    {
        Student[] random = { new Student("student name 1", 1),
            new Student("student name 2", 2),
            new Student("student name 3", 3),
            new Student("student name 4", 4),
            new Student("student name 5", 5)};
        int index = Rng.Next(0, 4);
        return random[index];
    }
    public override Student Clone()
    {
        return new Student(Name, Age);
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Student)) return false;
        if (((Person)obj).Age != Age || ((Person)obj).Name != Name) return false;
        return ((Student)obj).Course == Course;
    }
    public override string ToString()
    {
        return "Student " + Name + ", Age: " + Age + ", Course: " + Course;
    }
    public override void Print()
    {
        Console.WriteLine($"Student {Name}, Age: {Age}, Course: {Course}");
    }
    public override int GetHashCode()
    {
        return Course + 2000 + (10000 * Age);
    }
}