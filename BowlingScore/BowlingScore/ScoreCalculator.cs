using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore
{
    class ScoreCalculator
    {
        int currentFrame = 0;
        public string[] frames = new string[10];
        public int[] scorePerFrame = new int[10];
        string score;

        public ScoreCalculator(string score)
        {
            this.score = score;
        }
        public int Calculate()
        {
            CreateFrames();
            GetScoreFromFrame();

            int totalScore = 0;

            for (int i = 0; i < frames.Length; i++)
            {
                totalScore += scorePerFrame[i];
            }

            return totalScore;
        }
        private void CreateFrames()
        {
            string frame = "";
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] != ' ')
                {
                    frame += score[i];
                }
                else
                {
                    frames[currentFrame] = frame;
                    currentFrame++;
                    frame = "";
                }
                if (i == score.Length - 1)
                {
                    frames[currentFrame] = frame;
                    currentFrame++;
                    frame = "";
                }
            }
        }
        private void GetScoreFromFrame()
        {
            for (int i = 0; i < frames.Length; i++)
            {
                if (i == 9)
                {
                    scorePerFrame[i] = GetFrameTenScore(i);
                }
                else if (frames[i] == "X")
                {
                    scorePerFrame[i] = 10 + GetNextTwo(i + 1);
                }
                else if (frames[i][1] == '/')
                {
                    scorePerFrame[i] = 10 + GetNextOne(i + 1);
                }
                else
                {
                    int rollOneScore;
                    int rollTwoScore;
                    string rollOne = frames[i][0].ToString();
                    string rollTwo = frames[i][1].ToString();

                    int.TryParse(rollOne, out rollOneScore);
                    int.TryParse(rollTwo, out rollTwoScore);
                    scorePerFrame[i] = rollOneScore + rollTwoScore;
                }
            }
        }
        private int GetNextTwo(int frame)
        {
            if (frames[frame][0] == 'X' && frames[frame + 1][0] == 'X')
            {
                return 20;
            }
            else if (frames[frame][0] == 'X')
            {
                int score = 10;
                int rollOneScore;
                string rollOne = frames[frame + 1][0].ToString();
                int.TryParse(rollOne, out rollOneScore);
                return score + rollOneScore;
            }
            else if (frames[frame][1] == '/')
            {
                return 10;
            }
            else
            {
                int rollOneScore;
                int rollTwoScore;
                string rollOne = frames[frame][0].ToString();
                string rollTwo = frames[frame][1].ToString();

                int.TryParse(rollOne, out rollOneScore);
                int.TryParse(rollTwo, out rollTwoScore);
                return rollOneScore + rollTwoScore;
            }
        }
        private int GetNextOne(int frame)
        {
            if (frames[frame] == "X")
            {
                return 10;
            }
            else
            {
                int rollOneScore;
                string rollOne = frames[frame][0].ToString();
                int.TryParse(rollOne, out rollOneScore);
                return rollOneScore;
            }
        }
        private int GetFrameTenScore(int frame)
        {
            int score = 0;
            if (frames[frame][0] == 'X' && frames[frame][1] == 'X' && frames[frame][2] == 'X')
            {
                return 30;
            }
            else if (frames[frame][1] == '/')
            {
                score = 10;
                if (frames[frame][1] == 'X')
                {
                    score += 10;
                }
                else
                {
                    int rollOneScore;
                    string rollOne = frames[frame][2].ToString();
                    int.TryParse(rollOne, out rollOneScore);
                    score += rollOneScore;
                }
                return score;
            }
            else
            {
                int rollOneScore;
                int rollTwoScore;
                string rollOne = frames[frame][0].ToString();
                string rollTwo = frames[frame][1].ToString();

                int.TryParse(rollOne, out rollOneScore);
                int.TryParse(rollTwo, out rollTwoScore);
                return rollOneScore + rollTwoScore;
            }
        }
        private int GetFrameTenNextRoll()
        {
            return 10;
        }
    }
}
