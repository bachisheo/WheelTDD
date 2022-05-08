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
        /// <summary>
        /// Проверка корректности возвращаемого методом количества
        /// открытых букв
        /// </summary>
        [TestMethod]
        public void TestLettersOpeningCount()
        {
            foreach (var word in GetWords())
            {
                var usedLetter = new HashSet<char>();
                var board = new Board(word);
                var lettersCount = PreCountWordStructure(word);
                for (int i = 0; i < word.Length; i++)
                {
                    if (!usedLetter.Contains(word[i]))
                    {
                        Assert.AreEqual(board.OpenLetter(word[i]), lettersCount[word[i]]);
                        usedLetter.Add(word[i]);
                    }
                    Assert.AreEqual(board.OpenLetter(word[i]), 0);
                }
            }
        }

        private Dictionary<char, int> PreCountWordStructure(string word)
        {
            var letters = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if(letters.ContainsKey(word[i]))
                    letters[word[i]]++;
                else
                {
                    letters.Add(word[i], 1);
                }
            }
            return letters;
        }
        /// <summary>
        /// Проверка метода, открывающего слово в случае,
        /// когда часть букв уже была открыта
        /// </summary>
        [TestMethod]
        public void TestWordOpeningPartially()
        {
            foreach (var word in GetWords())
            {
                foreach (var letter in PreCountWordStructure(word))
                {
                    var board = new Board(word);
                    board.OpenLetter(letter.Key);
                    Assert.AreEqual(board.OpenWord(), word.Length - letter.Value);
                    Assert.AreEqual(word, board.State);
                }
            }
        }

    }
}