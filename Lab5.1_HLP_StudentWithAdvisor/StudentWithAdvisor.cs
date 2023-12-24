using System.Xml.Linq;
using System;

return;

public class StudentWithAdvisor : Student
{
    public Teacher Advisor { get; set; }
    public StudentWithAdvisor(Student student, Teacher teacher) : base(student.Name, student.Age)
    {
        Course = student.Course;
        Advisor = teacher;
    }
    public StudentWithAdvisor(string name, int age, int course, Teacher teacher) : base(name, age)
    {
        Course = course;
        Advisor = teacher;
    }
    public override StudentWithAdvisor Clone()
    {
        StudentWithAdvisor output = new StudentWithAdvisor(Name, Age, Course, Advisor);
        Advisor.AddStudent(output);
        return output;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(StudentWithAdvisor)) return false;
        if (((Person)obj).Age != Age || ((Person)obj).Name != Name) return false;
        if (((StudentWithAdvisor)obj).Advisor != Advisor) return false;
        return ((StudentWithAdvisor)obj).Course == Course;
    }
    public override string ToString()
    {
        return "StudentWithAdvisor " + Name + ", Age: " + Age + ", Course: " + Course + ", Teacher assigned";
    }
    public override void Print()
    {
        Console.WriteLine($"StudentWithAdvisor {Name}, Age: {Age}, Course: {Course}, Teacher: [{Advisor}]");
    }
    public override int GetHashCode()
    {
        return Course + 4000 + (10000 * Age);
    }
}