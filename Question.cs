using System;

namespace ExaminationSystem
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        public Question() : this(string.Empty, string.Empty, 0)
        {
        }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public Question(string header, string body, int mark, int answersCount) : this(header, body, mark)
        {
            AnswerList = new Answer[answersCount];
        }

        public abstract object Clone();

        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            string text = $"{Header}\t\tMark ({Mark})\n{Body}\n";
            if (AnswerList != null)
            {
                for (int i = 0; i < AnswerList.Length; i++)
                {
                    if (AnswerList[i] != null)
                    {
                        text += $"{AnswerList[i]}\n";
                    }
                }
            }
            return text;
        }
    }
}
