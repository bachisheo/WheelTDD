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
        private string[] Tasks = { "ОБЛЕПИХА", "КАРАВАЙ", "ГАУБИЦА" };
        //Табло с загаданным словом
        public StringBuilder WordMask { get; private set; }
        public const char SecretSign = '_';

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
            WordMask = new StringBuilder();
            for (int i = 0; i < ActiveTask.Length; i++)
                WordMask.Append(SecretSign);
            return ActiveTask;
        }

        /// <summary>
        /// Сравнение ответа игрока и загаданного слова
        /// </summary>
        /// <param name="task">Ответ игрока (слово)</param>
        /// <returns>Соотвествие ответа загаданному слову</returns>
        public bool CheckGamersAnswer(string task)
        {
            return task.Equals(ActiveTask);
        }  
        /// <summary>
        /// Сравнение ответа игрока и загаданного слова
        /// </summary>
        /// <param name="sign">Ответ игрока (символ алфавита)</param>
        /// <returns>Соотвествие ответа загаданному слову</returns>
        public bool CheckGamersAnswer(char sign)
        {
            if (!ActiveTask.Contains(sign)) return false;
            OpenSigns(sign);
            return true;
        }

        /// <summary>
        /// Открыть на табло угаданные игроком буквы
        /// </summary>
        /// <param name="sign"></param>
        private void OpenSigns(char sign)
        {
            for (int i = 0; i < ActiveTask.Length; i++)
            {
                if (ActiveTask[i] == sign)
                {
                    WordMask[i] = sign;
                }
            }
        }
    }
}
