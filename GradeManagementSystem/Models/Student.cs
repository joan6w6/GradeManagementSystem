using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public string Name { get; set; }
    public double Grade { get; set; }

    public Student(string name, double grade)
    {
        Name = name;
        Grade = grade;
    }
}

