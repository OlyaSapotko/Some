using System;
using System.Text;

namespace FinalTask.Utils
{

    public static class Randomize
    {

        public static string RandomText()
        {
            StringBuilder builder = new StringBuilder();
            Random rnd = new Random();
            var length = rnd.Next(100);
            for (var i = 0; i < length; i++)
                builder.Append((char)rnd.Next('a', 'z' + 1));
            var rndText = builder.ToString();
            return rndText;
        }
    }
}
