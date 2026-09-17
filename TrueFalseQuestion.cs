using System;

namespace ExaminationSystem
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() : base("True | False Question", string.Empty, 0, 2)
        {
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
        }

        public TrueFalseQuestion(string body, int mark) : base("True | False Question", body, mark, 2)
        {
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
        }

        public override object Clone()
        {
            TrueFalseQuestion clone = new TrueFalseQuestion(Body, Mark);
            clone.RightAnswer = (Answer)RightAnswer?.Clone();
            clone.UserAnswer = (Answer)UserAnswer?.Clone();
            return clone;
        }

        public override string ToString()
        {
            return $"{Header}\t\tMark ({Mark})\n{Body}\n1. True\t\t2. False\n";
        }
    }
}
