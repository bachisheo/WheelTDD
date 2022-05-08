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
            for (int i = 0; i < _word.Length; i++)
                _state[i] = SecretSign;
        }
        /// <summary>
        /// Метод, открывающий букву в слове.
        /// </summary>
        /// <param name="c">Открываемая буква</param>
        public void OpenLetter(char c)
        {
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] == c)
                {
                    _state[i] = _word[i];
                }
            }
        }
        /// <summary>
        /// Проверка метода, открывающего угаданное слово целиком.
        /// </summary>
        public void OpenWord()
        {
            for (int i = 0; i < _word.Length; i++)
            {
                if (_state[i] == SecretSign)
                {
                    _state[i] = _word[i];
                }
            }
        }
 
    }
}