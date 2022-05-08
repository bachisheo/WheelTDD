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
        private Quest[] _quests = new[]
        {
            new Quest("Что использовали в Китае для глажки белья вместо утюга?", "СКОВОРОДА"),
            new Quest("Ювелиры часто говорят, что бриллиантам необходимо ... ?", "ОДИНОЧЕСТВО")
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
            _lastSpin = rand.Next(32) + 1;
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

        public void StartGameCycle()
        {

            Console.WriteLine("Приветствую вас на игре \"Поле чудес\"!" + GetHelp());
            string res = Console.ReadLine();
            while (res != "-e")
            {
                switch (res)
                {
                    case "": break;

                    case "-s":
                        InitNewGame(InputUsers());
                        StartWheel();
                        break;
                    case "-h":
                        Console.WriteLine(GetHelp());
                        break;
                    case "-r":
                        var sr = new StreamReader(@"GameRules.txt");
                        Console.Write(sr.ReadToEnd());
                        break;
                    default:
                        Console.WriteLine("Нет такой команды! Попробуйте снова. Для справки введите -h.");
                        break;
                }
                res = Console.ReadLine();
            }
        }

        private void SayQuestion()
        {
            Console.WriteLine("ВНИМАНИЕ, ВОПРОС!");
            Console.WriteLine(ActiveQuest.Question);
        }

        private void ShowBoard()
        {
            StringBuilder sb = new StringBuilder("|");
            foreach (var c in _game.Board.State)
            {
                sb.Append(c);
                sb.Append("|");
            }
            Console.WriteLine(sb);
        }
        public void StartWheel()
        {
            SayQuestion();
            bool needSpin = true;
            while (true)
            {
                var user = _users[_activeUserId];
                if (needSpin)
                {
                    ShowBoard();
                    Console.WriteLine("" + SpinWheel() + " очков на барабане! Буква?");
                }
                var answer = Console.ReadLine();
                if (isValid(answer))
                {
                    int score = InputUserAnswer(answer);
                    if (score == 0)
                    {
                        Console.WriteLine("Неверный ответ!");
                        if (_users.Length > 1)
                        {
                            user = _users[_activeUserId];
                            Console.WriteLine("Ход переходит к игроку " + user.Name + "(" + user.Score + " очков).");
                        }
                        needSpin = true;
                    }
                    else
                    {
                        Console.WriteLine("Верно! " + user.Name + ", вы заработали " + score + " очков (всего: " + user.Score + ").");
                        needSpin = true;
                        if (_game.IsAllOpen())
                        {
                            ShowBoard();
                            Console.WriteLine("Игрок " + user.Name + " стал победителем!");
                            Console.WriteLine(GetHelp());
                            return;
                        }
                    }
                }
                else
                {
                    switch (answer)
                    {
                        case "": break;
                        case "-h":
                            Console.WriteLine("-e : закончить тур;\n" +
                                              "-q : повторить вопрос;\n" +
                                              "-p : вывести названные ранее буквы.\n");
                            break;
                        case "-q":
                            SayQuestion();
                            break;
                        case "-p":
                            Console.WriteLine();
                            foreach (var c in _game.UsedLetters)
                            {
                                Console.Write(c);
                                Console.Write(", ");
                            }
                            break;
                        default:
                            Console.WriteLine("Введите букву от 'А' до 'Я' или слово целиком. Для справки введите -h.");
                            break;
                    }
                    needSpin = false;
                }

            }
        }

        private User[] InputUsers()
        {

            Console.WriteLine("Введите количество игроков:");
            var s = Console.ReadLine();
            int userCount = Int32.Parse(s);
            var users = new User[userCount];

            for (int i = 0; i < userCount; i++)
            {
                Console.WriteLine("Введите имя игрока #" + (i + 1) + ":");
                users[i] = new User();
                users[i].Name = Console.ReadLine();
            }

            return users;
        }

        bool isValid(string s)
        {
            foreach (var c in s)
            {
                if ((c < 'А' || c > 'Я') && (c < 'а' || c > 'я'))
                    return false;
            }
            return true;
        }

    }
    public class User
    {
        public int Score { get; set; } = 0;
        public string Name { get; set; } = String.Empty;

    }
}
