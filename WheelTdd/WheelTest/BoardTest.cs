using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelTdd;

namespace WheelTest
{
    [TestClass]
    public class BoardTest
    {
        /// <summary>
        /// Проверка корректности начального состояния табло
        /// для заданного слова
        /// </summary>
        [TestMethod]
        public void TestWordMask()
        {
            string word = "somestring";
            Board board = new Board(word);
            string boardState = board.State;
            Assert.AreEqual(boardState.Length, word.Length);
            for (int i = 0; i < word.Length; i++)
            {
                Assert.AreEqual(boardState[i], Board.SecretSign);
            }
        }

    }
}