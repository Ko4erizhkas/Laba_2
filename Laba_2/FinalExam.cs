using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    public class FinalExam : Exam
    {
        public string ExamName { get; set; }
        public FinalExam(string _ExamName, int _TimeLimit, List<Question> _Questions, int _MinScore, int _MaxScore)
            : base(_TimeLimit, _Questions, _MinScore, _MaxScore)
        { 
            this.ExamName = _ExamName;
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            foreach (var q in Questions)
            {
                if (q.ChoiceAnswer)
                {
                    CurrentScore += 1;
                }
            }
            res.AppendLine($"Final Score: {CurrentScore}/{MaxScore}");
            if (TestComplite())
            {
                res.AppendLine("You have passed the test!");
            }
            else
            {
                res.AppendLine("You failed the test!");
            }
            return res.ToString();
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Final Exam Name: {ExamName}");
        }
    }
}
