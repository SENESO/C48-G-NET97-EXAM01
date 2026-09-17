using System;

namespace ExaminationSystem
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }

        public Exam() : this(0, 0)
        {
        }

        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        public abstract void ShowExam();

        public abstract object Clone();

        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return $"Exam Time: {Time} Minutes | Number of Questions: {NumberOfQuestions}";
        }
    }
}
