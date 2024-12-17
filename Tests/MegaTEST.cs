using Laba_2;
namespace Tests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void CheckAnswer_CorrectAnswer_ReturnsTrue()
        {
            var answers = new Dictionary<int, string> { { 1, "A" }, { 2, "B" } };
            var question = new Question("Test?", "Choose:", answers, 1);

            var result = question.CheckAnswer(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckAnswer_WrongAnswer_ReturnsFalse()
        {
            var answers = new Dictionary<int, string> { { 1, "A" }, { 2, "B" } };
            var question = new Question("Test?", "Choose:", answers, 1);

            var result = question.CheckAnswer(2);

            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class TestingTests
    {
        [TestMethod]
        public void TestCompite_ScoreMeetsMin_ReturnsTrue()
        {
            var questions = new List<Question>
            {
                new Question("Q1", "D1", new Dictionary<int, string> { { 1, "A" } }, 1, 1),
                new Question("Q2", "D2", new Dictionary<int, string> { { 2, "B" } }, 2, 2)
            };
            var testing = new Testing(1, 2, questions);

            var result = testing.TestCompite();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCompite_ScoreBelowMin_ReturnsFalse()
        {
            var questions = new List<Question>
            {
                new Question("Q1", "D1", new Dictionary<int, string> { { 1, "A" } }, 1, 2)
            };
            var testing = new Testing(2, 10, questions);

            var result = testing.TestCompite();

            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class TrialTests
    {
        [TestMethod]
        public void TestComplite_ScoreBelowMin_ReturnsTrue()
        {
            var questions = new List<Question>
            {
                new Question("Q1", "D1", new Dictionary<int, string> { { 1, "A" } }, 1, 2)
            };
            var trial = new Trial(questions, 1, 10);

            var result = trial.TestComplite();

            Assert.IsTrue(result);
        }
    }
    [TestClass]
    public class ExamTests
    {
        [TestMethod]
        public void Exam_ToString_ReturnsCorrectScore()
        {
            var questions = new List<Question>
            {
                new Question("Q1", "D1", new Dictionary<int, string> { { 1, "A" } }, 1, 1),
                new Question("Q2", "D2", new Dictionary<int, string> { { 2, "B" } }, 2, 1)
            };
            var exam = new Exam(60, questions, 1, 2);

            var result = exam.ToString();

            StringAssert.Contains(result, "Final Score: 1/2");
        }
    }
    [TestClass]
    public class FinalExamTests
    {
        [TestMethod]
        public void PrintInfo_ReturnsCorrectExamName()
        {
            var questions = new List<Question>();
            var finalExam = new FinalExam("Graduation Exam", 120, questions, 1, 2);
        }
    }
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void OperatorPlus_AddsElementToBeginning()
        {
            // Arrange
            var list = new Laba_2.List(new int[] { 3, 6, 1 });

            // Act
            var result = 1 + list;

            // Assert
            Assert.AreEqual("List(1, 3, 6, 1)", result.ToString());
        }

        [TestMethod]
        public void OperatorDecrement_RemovesFirstElement()
        {
            // Arrange
            var list = new Laba_2.List(new int[] { 3, 6, 1 });

            // Act
            var result = --list;

            // Assert
            Assert.AreEqual("List(6, 1)", result.ToString());
        }

        [TestMethod]
        public void OperatorEquality_TwoListsAreEqual_ReturnsTrue()
        {
            // Arrange
            var list1 = new Laba_2.List(new int[] { 3, 6, 1 });
            var list2 = new Laba_2.List(new int[] { 3, 6, 1 });

            // Act
            var result = list1 == list2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorInequality_TwoListsAreNotEqual_ReturnsTrue()
        {
            // Arrange
            var list1 = new Laba_2.List(new int[] { 3, 6, 1 });
            var list2 = new Laba_2.List(new int[] { 1, 2, 3 });

            // Act
            var result = list1 != list2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorMultiply_CombinesTwoLists()
        {
            // Arrange
            var list1 = new Laba_2.List(new int[] { 3, 6, 1 });
            var list2 = new Laba_2.List(new int[] { 4, 5 });

            // Act
            var result = list1 * list2;

            // Assert
            Assert.AreEqual("List(3, 6, 1, 4, 5)", result.ToString());
        }
    }
}