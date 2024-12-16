using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GradeManager
{
    private List<Student> students = new List<Student>();

    // 添加學生
    public void AddStudent(string name, double grade)
    {
        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("成績應該在 0 到 100 之間！");
            return;
        }
        students.Add(new Student(name, grade));
    }

    // 計算平均分
    public double GetAverageGrade()
    {
        return students.Count > 0 ? students.Average(s => s.Grade) : 0;
    }

    // 獲取最高分
    public double GetHighestGrade()
    {
        return students.Count > 0 ? students.Max(s => s.Grade) : 0;
    }

    // 獲取最低分
    public double GetLowestGrade()
    {
        return students.Count > 0 ? students.Min(s => s.Grade) : 0;
    }

    // 按成績排序
    public void SortByGrade()
    {
        students = students.OrderByDescending(s => s.Grade).ToList();
    }

    // 顯示所有學生
    public void DisplayStudents()
    {
        Console.WriteLine("學生姓名\t成績");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}\t{student.Grade}");
        }
    }

    // 保存到文件
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.Name},{student.Grade}");
            }
        }
        Console.WriteLine($"數據已保存到 {filePath}");
    }

    // 從文件加載數據
    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("文件不存在！");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && double.TryParse(parts[1], out double grade))
                {
                    AddStudent(parts[0], grade);
                }
            }
        }
        Console.WriteLine($"數據已從 {filePath} 加載");
    }

    //返回所有學生數據
    public List<Student> GetAllStudents()
    {
        return students;
    }
}
