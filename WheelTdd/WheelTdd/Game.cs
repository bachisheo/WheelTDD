using System.Collections.Generic;

namespace WheelTdd
{
    public class Game
    {
        private string _word;

        public Game(string word)
        {
            _word = word;
            Board = new Board(_word);
        }
        public Board Board { get; private set; }
        public HashSet<char> UsedLetters { get; private set; } = new();
        public int CheckUserAnswer(char c)
        {
            if (!_word.Contains(c) || UsedLetters.Contains(c))
                return 0;
            return Board.OpenLetter(c);
        }
        public int CheckUserAnswer(string word)
        {
            if (word != _word)
                return 0;
            return Board.OpenWord();
        }
    }
}