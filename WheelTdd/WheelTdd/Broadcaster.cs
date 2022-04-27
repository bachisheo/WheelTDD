using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTdd
{
    /// <summary>
    /// Класс, реализующий функционал ведущего игры
    /// </summary>
    public class Broadcaster
    {
        
        /// <summary>
        /// Приветсвие игрока ведущим игры
        /// </summary>
        /// <returns>Текст приветствия</returns>
        public string SayGreeting()
        {
            //todo сделать вывод правил игры
            return "Приветствую вас на игре \"Поле чудес\"!";
        }
    }
}
