using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    public class Trial
    {
        public string TrialName { get; set; }
        public List<Question> Questions { get; set; }
        public int CurrentScore { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public Trial(List<Question> _Questions, int _MinScore, int _MaxScore)
        {
            this.Questions = _Questions;
            this.MinScore = _MinScore;
            this.MaxScore = _MaxScore;
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
        public bool TestComplite()
        {
            if (CurrentScore <= MinScore)
            {
                return true;
            }
            return false;
        }
        public void EnterTrialName()
        {
            Console.Write("Введите название испытания: ");
            TrialName = Console.ReadLine();
        }
    }
}
