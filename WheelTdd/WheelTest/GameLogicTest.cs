using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelTdd;

namespace WheelTest
{
    /// <summary>
    /// Unit тесты для класса GameLogic,
    /// реализующего функционал ведущего игры
    /// </summary>
    [TestClass]
    public class GameLogicTest
    {
        /// <summary>
        /// Проверка приветствия игроков ведущим
        /// </summary>
        [TestMethod]
        public void TestGreeting()
        {
            var game = new GameLogic();
            Assert.AreNotEqual(game.GetHelp(), string.Empty);
        }

        /// <summary>
        /// Проверка выбора нового задания ведущим
        /// </summary>
        [TestMethod]
        public void TestSelectNewTask()
        {
            var game = new GameLogic();
            var oldGame = game.SelectNewQuest();
            var newGame = game.SelectNewQuest();
            Assert.AreNotEqual(oldGame, newGame);
        }

        /// <summary>
        /// Тест для метода проверки ответа игрока
        /// </summary>
        [TestMethod]
        public void TestInputUserAnswer()
        {
            User[] users = new[] { new User() };
            var game = new GameLogic();
            game.InitNewGame(users);
            int wheelScore = game.SpinWheel();
            var answer = game.ActiveQuest.Answer;
            game.InputUserAnswer(answer);
            Assert.AreEqual(wheelScore * answer.Length, users[0].Score);
        }
        }

    }

   
}
