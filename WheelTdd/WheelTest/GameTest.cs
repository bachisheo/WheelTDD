using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelTdd;

namespace WheelTest
{
    [TestClass]
    public class GameTest
    {
        private Quest[] GetQuests()
        {
            return new[]
            {
                new Quest("Что использовали в Китае для глажки белья вместо утюга", "СКОВОРОДА"),
                new Quest("Ювелиры часто говорят, что бриллиантам необходимо это.", "ОДИНОЧЕСТВО")
            };
        }
        [TestMethod]
        public void TestCheckUserAnswerLetter()
        {
            foreach (var task in GetQuests())
            {
                var game = new Game(task.Answer);
                var letters = BoardTest.PreCountWordStructure(task.Answer);
                for (char c = 'А'; c <= 'Я'; c++)
                {
                    Assert.AreEqual(game.CheckUserAnswer(c), letters.ContainsKey(c) ? letters[c] : 0);
                }
            }
        }
        [TestMethod]
        public void TestCheckUserAnswerWord()
        {
            foreach (var task in GetQuests())
            {
                var game = new Game(task.Answer);
                Assert.AreEqual(game.CheckUserAnswer(task.Answer), task.Answer.Length);
            }
        }
        [TestMethod]
        public void TestCheckUserAnswerPartially()
        {
            foreach (var task in GetQuests())
            {
                for (char c = 'А'; c <= 'Я'; c++)
                {
                    var game = new Game(task.Answer);
                    int openLetters = game.CheckUserAnswer(c);
                    Assert.AreEqual(game.CheckUserAnswer(task.Answer), task.Answer.Length - openLetters);
                }
            }
        }

        [TestMethod]
        public void TestAllOpenedMethod()
        {
            foreach (var task in GetQuests())
            {
                for (char c = 'А'; c <= 'Я'; c++)
                {
                    var game = new Game(task.Answer);
                    Assert.IsFalse(game.IsAllOpen());
                    if(game.CheckUserAnswer(c) < task.Answer.Length)
                        Assert.IsFalse(game.IsAllOpen());
                    game.CheckUserAnswer(task.Answer);
                    Assert.IsTrue(game.IsAllOpen());
                }
            }
        }
    }
}
