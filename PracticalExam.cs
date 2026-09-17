using System;

namespace ExaminationSystem
{
    public class PracticalExam : Exam
    {
        public PracticalExam() : base()
        {
        }

        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine(Questions[i]);
                Console.WriteLine("---------------------------------------------");

                int answerId;
                do
                {
                    Console.Write("Please Enter The Answer Id: ");
                } while (!int.TryParse(Console.ReadLine(), out answerId) || answerId < 1 || answerId > Questions[i].AnswerList.Length);

                Questions[i].UserAnswer = Questions[i].AnswerList[answerId - 1];
                Console.WriteLine("=============================================\n");
            }

            try { Console.Clear(); } catch { }
            Console.WriteLine("================ Practical Exam Right Answers ================");

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Q{i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Your Answer: {Questions[i].UserAnswer.AnswerText}");
                Console.WriteLine($"Right Answer: {Questions[i].RightAnswer.AnswerText}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public override object Clone()
        {
            PracticalExam clone = new PracticalExam(Time, NumberOfQuestions);
            clone.Subject = Subject;

            if (Questions != null)
            {
                for (int i = 0; i < Questions.Length; i++)
                {
                    clone.Questions[i] = (Question)Questions[i]?.Clone();
                }
            }

            return clone;
        }
    }
}
