using System.Xml.Linq;
using System;

return;
public class Teacher : Person
{
    List<Student> students;
    public List<Student> Students
    {
        get { return students; }
        set { students = value; }
    }
    public Teacher(string name, int age) : base(name, age)
    {
        students = new();
    }
    public static Teacher RandomTeacher()
    {
        Teacher[] random = { new Teacher("teacher name 1", 1),
            new Teacher("teacher name 2", 2),
            new Teacher("teacher name 3", 3),
            new Teacher("teacher name 4", 4),
            new Teacher("teacher name 5", 5)};
        int index = Rng.Next(0, 4);
        return random[index];
    }
    public void AddStudent(Student student)
    {
        students.Add(student);
    }
    public override Teacher Clone()
    {
        Teacher output = new Teacher(Name, Age);
        output.Students = new List<Student>();
        return output;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Teacher)) return false;
        if (((Person)obj).Age != Age || ((Person)obj).Name != Name) return false;
        if (Students.Count != ((Teacher)obj).Students.Count) return false;
        foreach (var student in Students)
        {
            if (!((Teacher)obj).Students.Contains(student)) return false;
        }
        return true;
    }
    public override string ToString()
    {
        return "Teacher " + Name + ", Age: " + Age + ", Students: " + Students.Count;
    }
    public override void Print()
    {
        Console.WriteLine($"Teacher {Name}, Age: {Age}, Students list:");
        for (var i = 0; i < Students.Count; i++)
        {
            Students[i].Print();
        }
    }
    public override int GetHashCode()
    {
        return Students.Count + 3000 + (10000 * Age);
    }
}
