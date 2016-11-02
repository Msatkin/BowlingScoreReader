using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore
{
    class Main
    {
        ScoreCalculator calculator;
        List<string> scores;
        public void Run()
        {
            ScoreReader reader = new ScoreReader();
            scores = reader.scores;
            foreach (string score in scores)
            {
            calculator = new ScoreCalculator(score);
            Console.WriteLine("Score: {0}",calculator.Calculate());
            }
            Console.ReadLine();
        }
    }
}
