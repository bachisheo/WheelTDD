﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    }
}
