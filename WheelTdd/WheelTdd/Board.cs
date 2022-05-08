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
        /// <returns>Количество открытых букв</returns>
        public int OpenLetter(char c)
        {
            int countLetter = 0;
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] == c && _state[i] == SecretSign)
                {
                    countLetter++;
                    _state[i] = _word[i];
                }
            }
            return countLetter;
        }
        /// <summary>
        /// Проверка метода, открывающего угаданное слово целиком.
        /// </summary>
        public int OpenWord()
        {
            int countLetter = 0;
            for (int i = 0; i < _word.Length; i++)
            {
                if (_state[i] == SecretSign)
                {
                    _state[i] = _word[i];
                    countLetter++;
                }
            }
            return countLetter;
        }
    }
}