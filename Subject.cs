using System;

namespace ExaminationSystem
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject() : this(0, string.Empty)
        {
        }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            int examType;
            do
            {
                Console.Write("Please Enter The Type Of Exam (1 for Practical | 2 for Final): ");
            } while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            int time;
            do
            {
                Console.Write("Please Enter The Time Of Exam In Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);

            int numberOfQuestions;
            do
            {
                Console.Write("Please Enter The Number Of Questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0);

            if (examType == 1)
            {
                Exam = new PracticalExam(time, numberOfQuestions);
            }
            else
            {
                Exam = new FinalExam(time, numberOfQuestions);
            }

            Exam.Subject = this;

            try { Console.Clear(); } catch { }

            for (int i = 0; i < numberOfQuestions; i++)
            {
                int questionType = 2; // MCQ for Practical

                if (examType == 2)
                {
                    do
                    {
                        Console.Write($"Please Choose Question Type for Q{i + 1} (1 for True/False || 2 for MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2));
                }

                try { Console.Clear(); } catch { }
                Console.WriteLine($"=== Question {i + 1} ===");

                Console.Write("Please Enter The Body Of Question: ");
                string body = Console.ReadLine();

                int mark;
                do
                {
                    Console.Write("Please Enter The Mark Of Question: ");
                } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                if (questionType == 1)
                {
                    TrueFalseQuestion tfQuestion = new TrueFalseQuestion(body, mark);

                    int rightAnswerId;
                    do
                    {
                        Console.Write("Please Enter The Right Answer Id (1 for True | 2 for False): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAnswerId) || (rightAnswerId != 1 && rightAnswerId != 2));

                    tfQuestion.RightAnswer = tfQuestion.AnswerList[rightAnswerId - 1];
                    Exam.Questions[i] = tfQuestion;
                }
                else
                {
                    int choicesCount;
                    do
                    {
                        Console.Write("Please Enter Number of Choices : ");
                    } while (!int.TryParse(Console.ReadLine(), out choicesCount) || choicesCount < 2);

                    McqQuestion mcqQuestion = new McqQuestion(body, mark, choicesCount);
                    Console.WriteLine("The Choices of Question:");

                    for (int j = 0; j < choicesCount; j++)
                    {
                        Console.Write($"Please Enter Choice Number {j + 1}: ");
                        string choiceText = Console.ReadLine();
                        mcqQuestion.AnswerList[j] = new Answer(j + 1, choiceText);
                    }

                    int rightAnswerId;
                    do
                    {
                        Console.Write("Please Enter The Right Answer Id: ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAnswerId) || rightAnswerId < 1 || rightAnswerId > choicesCount);

                    mcqQuestion.RightAnswer = mcqQuestion.AnswerList[rightAnswerId - 1];
                    Exam.Questions[i] = mcqQuestion;
                }

                try { Console.Clear(); } catch { }
            }
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName} (ID: {SubjectId})";
        }
    }
}
