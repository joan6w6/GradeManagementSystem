using System;

namespace GradeManagementSystem.Views
{
    public class ConsoleView
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- 成績管理系統 ---");
            Console.WriteLine("1. 添加學生");
            Console.WriteLine("2. 顯示所有學生");
            Console.WriteLine("3. 計算平均分");
            Console.WriteLine("4. 顯示最高分");
            Console.WriteLine("5. 顯示最低分");
            Console.WriteLine("6. 按成績排序");
            Console.WriteLine("7. 保存到文件");
            Console.WriteLine("8. 從文件加載");
            Console.WriteLine("9. 退出");
            Console.Write("請選擇操作：");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowStudents(string studentList)
        {
            Console.WriteLine("學生姓名\t成績");
            Console.WriteLine(studentList);
        }

        public string PromptInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
