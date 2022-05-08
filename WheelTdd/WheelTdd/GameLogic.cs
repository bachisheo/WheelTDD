using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WheelTdd
{
    /// <summary>
    /// Класс, реализующий функционал ведущего игры
    /// </summary>
    public class GameLogic
    {
        private int _lastSpin = 1;
        private User _currentUser;
        private Game _currentGame;
        //todo вынести задания (задагаддные слова, вопросы) в отдельный класс
        private Quest[] _quests = new []
        {
            new Quest("Что использовали в Китае для глажки белья вместо утюга", "СКОВОРОДА"),
            new Quest("Ювелиры часто говорят, что бриллиантам необходимо это.", "ОДИНОЧЕСТВО")
        };

    public Quest ActiveQuest { get; private set; }
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
        public Quest SelectNewQuest()
        {
            ActiveQuest = _quests.First(x => x != ActiveQuest);
            _currentGame = new Game(ActiveQuest.Answer);
            return ActiveQuest;
        }

        /// <summary>
        /// Сравнение ответа игрока и загаданного слова
        /// </summary>
        /// <param name="task">Ответ игрока</param>
        public void InputUserAnswer(string answer)
        {
            int score;
            if (answer.Length == 1)
                score = _currentGame.CheckUserAnswer(answer[0]);
            else score = _currentGame.CheckUserAnswer(answer);
            _currentUser.Score += score * _lastSpin;
        }

        public int SpinWheel()
        {
            var rand = new Random(DateTime.Now.Second);
            _lastSpin = rand.Next(32);
            return _lastSpin;
        }
        /// <summary>
        /// Выбрать другое задание (новое слово)
        /// </summary>
        /// <returns></returns>
        public void StartNewGame(User user)
        {
            _currentUser = user;
            ActiveQuest = _quests.First(x => x != ActiveQuest);
            _currentGame = new Game(ActiveQuest.Answer);
        }

    }
    public class User
    {
        public int Score { get; set; } = 0;
    }
}
