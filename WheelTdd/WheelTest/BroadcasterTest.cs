using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelTdd;

namespace WheelTest
{
    /// <summary>
    /// Unit тесты для класса Broadcaster,
    /// реализующего функционал ведущего игры
    /// </summary>
    [TestClass]
    public class BroadcasterTest
    {
        /// <summary>
        /// Проверка приветствия игроков ведущим
        /// </summary>
        [TestMethod]
        public void TestGreeting()
        {
            var broadcaster = new Broadcaster();
            Assert.AreNotEqual(broadcaster.SayGreeting(), string.Empty);
        }

        /// <summary>
        /// Проверка выбора нового задания ведущим
        /// </summary>
        [TestMethod]
        public void TestSelectNewTask()
        {
            var broadcaster = new Broadcaster();
            var oldGame = broadcaster.SelectNewTask();
            var newGame = broadcaster.SelectNewTask();
            Assert.AreNotEqual(oldGame, newGame);
        }

        /// <summary>
        /// Тест для проверки ведущим ответа игрока
        /// </summary>
        [TestMethod]
        public void TestCheckUserAnswer()
        {
            //@todo если буква повторяется - ответ не засчитывать
            //@todo Завершать игру при выборе верного слова
            var broadcaster = new Broadcaster();
            broadcaster.SelectNewTask();
            var task = broadcaster.ActiveTask;
            Assert.IsTrue(broadcaster.CheckGamersAnswer(task));
            Assert.IsFalse(broadcaster.CheckGamersAnswer(task + task));
        }
        /// <summary>
        /// Тест для проверки маски загаданного слова.
        /// Проверяем каждую букву слова, последовательно открывая
        /// встречающиеся на пути буквы.
        /// Использованные ранее буквы уже должны быть открыты.
        /// </summary>
        [TestMethod]
        public void TestWordMask()
        {
            var broadcaster = new Broadcaster();
            broadcaster.SelectNewTask();
            var task = broadcaster.ActiveTask;
            var isUsed = new BitArray(32);
            for (var i = 0; i < task.Length; i++)
            {
                int ind = task[i] - 'А';
                if (!isUsed[ind])
                {
                    isUsed[ind] = true;
                    Assert.AreEqual(broadcaster.WordMask[i], Broadcaster.SecretSign);
                    broadcaster.CheckGamersAnswer(task[i]);
                }
                Assert.AreEqual(broadcaster.WordMask[i], task[i]);
            }
            Assert.AreEqual(broadcaster.ActiveTask, broadcaster.WordMask.ToString());
        }
    }
}
