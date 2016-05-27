using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinExample
{
    public class Question
    {
        public int id;
        public string text;
        public List<Answer> answers;

        public Question()
        {
            answers = new List<Answer>();
        }
    }

    public class Answer
    {
        public int id;
        public string text;
        public int value;
        public int questionid;
    }
}
