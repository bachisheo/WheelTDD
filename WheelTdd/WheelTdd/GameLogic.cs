using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WheelTdd
{
    /// <summary>
    /// Класс, реализующий функционал ведущего игры
    /// </summary>
    public class GameLogic
    {
        private int _lastSpin = 1;
        private int _activeUserId;
        private Game _game;
        public User ActiveUser
        {
            get => _users[_activeUserId];
        }
        private User[] _users;
        //todo вынести задания (задагаддные слова, вопросы) в отдельный класс
        private Quest[] _quests = new []
        {
            new Quest("Что использовали в Китае для глажки белья вместо утюга", "СКОВОРОДА"),
            new Quest("Ювелиры часто говорят, что бриллиантам необходимо это.", "ОДИНОЧЕСТВО")
        };

        public Quest ActiveQuest { get; private set; }

        public string GetHelp()
        {
            return "\n -s : начать игру;" +
                   "\n -h : данная справка;" +
                   "\n -r : правила игры;" +
                   "\n -e : выйти из игры.";
        }
        /// <summary>
        /// Выбрать другое задание (новое слово)
        /// </summary>
        /// <returns></returns>
        public Quest SelectNewQuest()
        {
            ActiveQuest = _quests.First(x => x != ActiveQuest);
            _game = new Game(ActiveQuest.Answer);
            return ActiveQuest;
        }

        /// <summary>
        /// Сравнение ответа игрока и загаданного слова
        /// </summary>
        /// <param name="task">Ответ игрока</param>
        public int InputUserAnswer(string answer)
        {
            answer = answer.ToUpperInvariant();
            int score;
            if (answer.Length == 1)
                score = _game.CheckUserAnswer(answer[0]);
            else score = _game.CheckUserAnswer(answer);
            score *= _lastSpin;
            if (score > 0)
                _users[_activeUserId].Score += score;
            else
                _activeUserId = (_activeUserId + 1) % _users.Length;
            return score;
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
        public void InitNewGame(User[] users)
        {
            _users = users;
            _activeUserId = 0;
            ActiveQuest = _quests.First(x => x != ActiveQuest);
            _game = new Game(ActiveQuest.Answer);
        }
        }

    }
    public class User
    {
        public int Score { get; set; } = 0;
    }
}
