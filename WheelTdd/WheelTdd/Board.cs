using System;
using System.Linq;

namespace WheelTdd
{
    /// <summary>
    /// Доска с загаданным словом, управляет
    /// скрытыем/ отображением символов. 
    /// </summary>
    public class Board
    {
        //Табло с загаданным словом
        public const char SecretSign = '_';
        public string State => new string(_state);
        private char[] _state;
        private string _word;

        public Board(string Word)
        {
            _word = Word;
            _state = new char[_word.Length];
            for(int i = 0; i < _word.Length; i++)
                _state[i] = SecretSign;
        }
    }
}