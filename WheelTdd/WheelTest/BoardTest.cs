using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelTdd;

namespace WheelTest
{
    [TestClass]
    public class BoardTest
    {
        private string[] GetWords()
        {
            return new[] { "somestring", "other-string" };
        }
        /// <summary>
        /// Проверка корректности начального состояния табло
        /// для заданного слова
        /// </summary>
        [TestMethod]
        public void TestWordMask()
        {
            foreach (var word in GetWords())
            {
                Board board = new Board(word);
                string boardState = board.State;
                Assert.AreEqual(boardState.Length, word.Length);
                for (int i = 0; i < word.Length; i++)
                {
                    Assert.AreEqual(boardState[i], Board.SecretSign);
                }
            }
        }

        [TestMethod]
        public void TestLettersOpening()
        {
            foreach (var word in GetWords())
            {
                var usedLetter = new HashSet<char>();
                var board = new Board(word);
                for (int i = 0; i < word.Length; i++)
                {
                    if (!usedLetter.Contains(word[i]))
                    {
                        Assert.AreEqual(board.State[i], Board.SecretSign);
                        board.OpenLetter(word[i]);
                        usedLetter.Add(word[i]);
                    }
                    Assert.AreEqual(board.State[i], word[i]);
                }
            }
        }        
        [TestMethod]
        public void TestWordOpening()
        {
            foreach (var word in GetWords())
            {
                var board = new Board(word);
                board.OpenWord();
                Assert.AreEqual(word, board.State);
            }
        }

    }
}