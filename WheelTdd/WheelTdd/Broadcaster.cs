using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WheelTdd
{
    /// <summary>
    /// Класс, реализующий функционал ведущего игры
    /// </summary>
    public class Broadcaster
    {
        //todo вынести задания (задагаддные слова, вопросы) в отдельный класс
        private string[] Tasks = { "Облепиха", "Каравай", "Гаубица" };

        public string ActiveTask { get; private set; } = string.Empty;
        /// <summary>
        /// Приветсвие игрока ведущим игры
        /// </summary>
        /// <returns>Текст приветствия</returns>
        public string SayGreeting()
        {
            //todo сделать вывод правил игры
            return "Приветствую вас на игре \"Поле чудес\"!";
        }

        /// <summary>
        /// Выбрать другое задание (новое слово)
        /// </summary>
        /// <returns></returns>
        public object SelectNewTask()
        {
            ActiveTask = Tasks.First(x => x != ActiveTask);
            return ActiveTask;
        }
    }
}
