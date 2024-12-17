using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Laba_2
{
    interface IQuestion
    {
        void PrintInfo();
    }
    public class Question : IQuestion
    {
        public string? Problem { get; set; }
        public string? Description { get; set; }
        public Dictionary<int, string> AnswerOptions { get; set; }
        public int RightAnswer { get; set; }
        public bool ChoiceAnswer { get; private set; }
        public int UserChoice { get; set; }
        public Question(string _Problem, string _Description, Dictionary<int, string> _AnswerOptions, int _RightAnswer, int _UserChoice)
        {
            this.Problem = _Problem;
            this.Description = _Description;
            this.AnswerOptions = _AnswerOptions;
            this.RightAnswer = _RightAnswer;
            this.UserChoice = _UserChoice;
            ChoiceAnswer = CheckAnswer(_UserChoice);
        }
        public Question(string _Problem, string _Description, Dictionary<int, string> _AnswerOptions, int _RightAnswer)
        {
            this.Problem = _Problem;
            this.Description = _Description;
            this.AnswerOptions = _AnswerOptions;
            this.RightAnswer = _RightAnswer;
            ChoiceAnswer = CheckAnswer(_RightAnswer);
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine($"Problem: {Problem}");
            res.AppendLine($"Description: {Description}");
            res.AppendLine($"Answer: ");
            foreach (var (key, val) in AnswerOptions)
            {
                res.AppendLine($"{key}. {val}");
            }
            return res.ToString();
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Проблема: {Problem}");
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine("Вопросы: ");
            foreach (var (key, val) in AnswerOptions)
            {
                Console.WriteLine($"{key}. {val}");
            }
            Console.WriteLine($"Правильный ответ: {RightAnswer}");
        }
        public bool CheckAnswer(int response)
        {
            return response == RightAnswer;
        }
        public void EnterAnswer()
        {
            string answer;
            short count = 0;
            AnswerOptions.Clear();
            AnswerOptions = new Dictionary<int, string>();
            
            Console.Write("Введите кол-во ответов: ");
            count = Convert.ToInt16(Console.ReadLine());
            
            Console.WriteLine("Введите ответы: ");
            for (int i = 0; i < count; i++)
            {
                answer = Console.ReadLine();
                AnswerOptions.Add(i + 1,answer);
            }
            foreach (var item in AnswerOptions)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }

            Console.WriteLine("Установите номер правильного ответа: ");
            RightAnswer = Convert.ToInt32(Console.ReadLine());
            
        }
        private void PrintAnswers()
        {
            foreach (var item in AnswerOptions)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }
        }
    }
    //internal class MainQuestion
    //{
    //    static public void Main()
    //    {
    //        string problem = "Что такое жопа ежа?";
    //        string desc = "Существует ли такой термин как жопа ежа? Выберите один из ответов";
    //        Dictionary<int, string> answers = new Dictionary<int, string>
    //        {
    //            [1] = "Она сушествует!!",
    //            [2] = "Она не существует!",
    //            [3] = "А чёрт его знает :)"
    //        };
    //        int correctAnswer = 1;
    //        Question q = new Question(problem, desc, answers, correctAnswer);
    //        Console.WriteLine(q);
    //        Console.WriteLine("Ваш ответ: ");
    //        int userChoice = Convert.ToInt32(Console.ReadLine());

    //        if (q.CheckAnswer(userChoice))
    //        {
    //            Console.WriteLine("Ваш ответ правильный!");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Ваш ответ неверный!");
    //        }
    //    }
    //}
}
