using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BowlingScore
{
    class ScoreReader
    {
        public List<string> scores = new List<string>();

        public ScoreReader()
        {
            ReadFile();
        }

        private void ReadFile()
        {
            try
            {
                StreamReader reader = new StreamReader("scores.txt");
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    scores.Add(line);
                }
            }
            catch
            {
                Console.WriteLine("File not found.");
                Environment.Exit(0);
            }
        }
    }
}
