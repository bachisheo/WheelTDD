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
    }
}
