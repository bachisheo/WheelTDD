using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTdd
{
    public class Quest
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }

        public Quest(String question, String answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
