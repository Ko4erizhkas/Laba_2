using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    public sealed class Testing : Object
    {
        public List<Question> Questions { get; set; }
        public bool TestComplite { get; private set; }
        public int MinScoreForComplite { get; set; }
        public int MaxScoreInTest { get; set; }
        public int CurrentScore { get; private set; }
        public Testing(List<Question> _Questions)
        {
            this.Questions = _Questions;
        }
        public Testing(int _MinScore, int _MaxScore, List<Question> _Questions)
        {
            this.MinScoreForComplite = _MinScore;
            this.MaxScoreInTest = _MaxScore;
            this.Questions = _Questions;
        }
        public override string ToString()
        {
            CurrentScore = 0;
            StringBuilder res = new StringBuilder();
            
            foreach (var q in Questions)
            {
                if (q.ChoiceAnswer)
                {
                    CurrentScore += 1;
                }
            }
            res.AppendLine($"Final Score: {CurrentScore}/{MaxScoreInTest}");
            if (TestCompite())
            {
                res.AppendLine("You have passed the test!");
            }
            else
            {
                res.AppendLine("You failed the test!");
            }
            return res.ToString();
        }
        public void AddQuestions(Question question)
        {
            Questions.Add(question);
        }
        public bool TestCompite()
        {
            if (CurrentScore >= MinScoreForComplite)
            {
                return false;
            }
            else { return true; }
        }
        public new Type GetType()
        {
            return typeof(Testing);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var q in Questions)
            {
                hash = hash * 34 + (q?.GetHashCode() ?? 0);
            }
            return hash;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Testing))
            {
                return false;
            }
            return true;
        }
    }
    //internal class MainTesting
    //{
    //    static public void Main()
    //    {
    //        var dict = new Dictionary<int, string>()
    //        {
    //            [1] = "a",
    //            [2] = "b",
    //            [3] = "c",
    //            [4] = "d",
    //            [5] = "e",
    //        };
    //        List<Question> q = new List<Question>()
    //        {
    //            new Question("","", dict,1,1),
    //            new Question("","", dict,2,1),
    //            new Question("","", dict,1,1),
    //            new Question("","", dict,5,1),
    //            new Question("","", dict,3,1),
    //            new Question("","", dict,1,1)
    //        };
    //        Testing t = new Testing(1,10,q);
    //        Console.WriteLine(t);
    //    }
    //}
}
