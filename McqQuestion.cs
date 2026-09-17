using System;

namespace ExaminationSystem
{
    public class McqQuestion : Question
    {
        public McqQuestion() : base("Choose One Answer Question", string.Empty, 0, 4)
        {
        }

        public McqQuestion(string body, int mark, int choicesCount = 4) : base("Choose One Answer Question", body, mark, choicesCount)
        {
        }

        public override object Clone()
        {
            int count = AnswerList != null ? AnswerList.Length : 0;
            McqQuestion clone = new McqQuestion(Body, Mark, count);

            if (AnswerList != null)
            {
                clone.AnswerList = new Answer[AnswerList.Length];
                for (int i = 0; i < AnswerList.Length; i++)
                {
                    clone.AnswerList[i] = (Answer)AnswerList[i]?.Clone();
                }
            }

            clone.RightAnswer = (Answer)RightAnswer?.Clone();
            clone.UserAnswer = (Answer)UserAnswer?.Clone();
            return clone;
        }
    }
}
