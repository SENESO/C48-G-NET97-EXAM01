using System;
using System.Diagnostics;

namespace ExaminationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10, "C# Programming");
            sub1.CreateExam();

            try { Console.Clear(); } catch { }
            Console.Write("Do You Want To Start The Exam (y | n): ");
            char choice;
            while (!char.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Please enter 'y' or 'n': ");
            }

            if (choice == 'y' || choice == 'Y')
            {
                try { Console.Clear(); } catch { }
                Stopwatch sw = new Stopwatch();
                sw.Start();

                sub1.Exam.ShowExam();

                sw.Stop();
                Console.WriteLine($"\nThe Elapsed Time = {sw.Elapsed}");
            }
            else
            {
                Console.WriteLine("Exam cancelled. Thank you!");
            }
        }
    }
}
