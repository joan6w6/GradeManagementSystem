using System;
using GradeManagementSystem.Views;

namespace GradeManagementSystem.Controllers
{
    public class GradeController
    {
        private readonly GradeManager gradeManager;
        private readonly ConsoleView view;

        public GradeController()
        {
            gradeManager = new GradeManager();
            view = new ConsoleView();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                view.ShowMenu();
                string choice = view.PromptInput("");

                switch (choice)
                {
                    case "1":
                        string name = view.PromptInput("輸入學生姓名：");
                        if (double.TryParse(view.PromptInput("輸入成績："), out double grade))
                        {
                            gradeManager.AddStudent(name, grade);
                            view.ShowMessage("學生已添加！");
                        }
                        else
                        {
                            view.ShowMessage("無效的成績！");
                        }
                        break;

                    case "2":
                        view.ShowStudents(GetFormattedStudentList());
                        break;

                    case "3":
                        view.ShowMessage($"平均分：{gradeManager.GetAverageGrade():F2}");
                        break;

                    case "4":
                        view.ShowMessage($"最高分：{gradeManager.GetHighestGrade()}");
                        break;

                    case "5":
                        view.ShowMessage($"最低分：{gradeManager.GetLowestGrade()}");
                        break;

                    case "6":
                        gradeManager.SortByGrade();
                        view.ShowMessage("已按成績排序！");
                        break;

                    case "7":
                        gradeManager.SaveToFile("grades.txt");
                        view.ShowMessage("數據已保存到文件！");
                        break;

                    case "8":
                        gradeManager.LoadFromFile("grades.txt");
                        view.ShowMessage("數據已從文件加載！");
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        view.ShowMessage("無效選項！");
                        break;
                }
            }
        }

        private string GetFormattedStudentList()
        {
            var students = gradeManager.GetAllStudents(); // Add this method in GradeManager
            string result = string.Empty;

            foreach (var student in students)
            {
                result += $"{student.Name}\t{student.Grade}\n";
            }
            return result;
        }
    }
}
