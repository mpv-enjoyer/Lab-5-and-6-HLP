// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

int generated_teacher_count = Rng.Next(2, 4);
List<Person> people = new();
for (var i = 0; i < generated_teacher_count; i++)
{
    int generated_student_count = Rng.Next(1, 4);
    Teacher teacher = Teacher.RandomTeacher();
    people.Add(teacher);
    for (var j = 0; j < generated_student_count; j++)
    {
        if (Rng.Next(1, 4) == 1 && j != 0)
        {
            people.Add(Person.RandomPerson());
        }
        Student random = Student.RandomStudent();
        StudentWithAdvisor student_assigned = new(random, teacher);
        teacher.AddStudent(student_assigned);
        people.Add(student_assigned);
    }
}

int generated_clones_count = Rng.Next(1, 10);
for (var i = 0; i < generated_clones_count; i++)
{
    int index = Rng.Next(0, people.Count - 1);
    people.Add(people[index].Clone());
    Console.WriteLine($"Cloned {index} to {people.Count - 1}");
    if (people[index].GetType() != typeof(Teacher))
    {
        Debug.Assert(people[index].Equals(people[people.Count - 1]));
    }
}

for (var i = 0; i < people.Count; i++)
{
    Console.WriteLine($"{i}) {people[i]}, Hash: {people[i].GetHashCode()}");
}

int person_count = people.Count;
int student_count = 0;
int teacher_count = 0;
int student_with_advisor_count = 0;
foreach (var person in people)
{
    if (person is Student)
    {
        ((Student)person).Course++;
        student_count++;
    }
    if (person is Teacher) teacher_count++;
    if (person is StudentWithAdvisor) student_with_advisor_count++; 
}

Console.WriteLine("Include derived:");
Console.WriteLine($"person_count {person_count}");
Console.WriteLine($"student_count {student_count}");
Console.WriteLine($"teacher_count {teacher_count}");
Console.WriteLine($"student_with_advisor_count {student_with_advisor_count}");

student_count = 0;
teacher_count = 0;
student_with_advisor_count = 0;
person_count = 0;
foreach (var person in people)
{
    if (person.GetType() == typeof(Person)) person_count++;
    if (person.GetType() == typeof(Student)) student_count++;
    if (person.GetType() == typeof(Teacher)) teacher_count++;
    if (person.GetType() == typeof(StudentWithAdvisor)) student_with_advisor_count++;
}

Console.WriteLine("Exclude derived:");
Console.WriteLine($"person_count {person_count}");
Console.WriteLine($"student_count {student_count}");
Console.WriteLine($"teacher_count {teacher_count}");
Console.WriteLine($"student_with_advisor_count {student_with_advisor_count}");

Console.Write("Dumping people[i].Print() after Enter:");
Console.ReadLine();

for (var i = 0; i < people.Count; i++)
{
    Console.Write(i + ") ");
    people[i].Print();
}