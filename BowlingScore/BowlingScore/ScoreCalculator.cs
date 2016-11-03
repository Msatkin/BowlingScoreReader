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
                if (i < 7)
                {
                    GetNormalFrameScore(i);
                }
                else if (i == 7)
                {
                    GetEigthFrame();
                }
                else if (i == 8)
                {
                    GetNinthFrame();
                }
                else if (i == 9)
                {
                    GetTenthFrame();
                }
            }
        }
        private void GetNormalFrameScore(int frame)
        {
            if (frames[frame][0] == 'X')
            {
                scorePerFrame[frame] = 10 + GetNextTwo(frame + 1);
            }
            else if (frames[frame][1] == '/')
            {
                scorePerFrame[frame] = 10 + GetNextOne(frame + 1);
            }
            else
            {
                scorePerFrame[frame] = GetFirstRollScore(frame) + GetSecondRollScore(frame);
            }
        }
        private int GetFirstRollScore(int frame)
        {
            int roll;
            string rollOne = frames[frame][0].ToString();
            int.TryParse(rollOne, out roll);
            return roll;
        }
        private int GetSecondRollScore(int frame)
        {
            int roll;
            string rollTwo = frames[frame][1].ToString();
            int.TryParse(rollTwo, out roll);
            return roll;
        }
        private int GetNextTwo(int frame)
        {
            if (frames[frame][0] == 'X' && frames[frame + 1][0] == 'X')
            {
                return 20;
            }
            else if (frames[frame][0] == 'X')
            {
                return 10 + GetFirstRollScore(frame + 1);
            }
            else if (frames[frame][1] == '/')
            {
                return 10;
            }
            else
            {
                return GetFirstRollScore(frame) + GetSecondRollScore(frame);
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
                return GetFirstRollScore(frame);
            }
        }
        private void GetEigthFrame()
        {
            if (frames[7][0] == 'X' && frames[8][0] == 'X')
            {
                scorePerFrame[7] = 20 + GetTenthFrameValue(0);
            }
            else if (frames[7][0] == 'X' && frames[8][1] == '/')
            {
                scorePerFrame[7] = 20;
            }
            else if (frames[7][0] == 'X')
            {
                scorePerFrame[7] = 10 + GetFirstRollScore(7) + GetSecondRollScore(7);
            }
            else if (frames[7][1] == '/')
            {
                scorePerFrame[7] = 10 + GetFirstRollScore(8);
            }
            else
            {
                scorePerFrame[7] = GetFirstRollScore(7) + GetSecondRollScore(7);
            }
        }
        private void GetNinthFrame()
        {
            if (frames[8][0] == 'X' && frames[9][0] == 'X')
            {
                scorePerFrame[8] = 20 + GetTenthFrameValue(1);
            }
            else if (frames[8][0] == 'X' && frames[9][1] == '/')
            {
                scorePerFrame[8] = 20;
            }
            else if (frames[8][0] == 'X')
            {
                scorePerFrame[8] = 10 + GetTenthFrameValue(0) + GetTenthFrameValue(1);
            }
            else if (frames[8][1] == '/')
            {
                scorePerFrame[8] = 10 + GetTenthFrameValue(0);
            }
            else
            {
                scorePerFrame[8] = GetFirstRollScore(8) + GetSecondRollScore(8);
            }
        }
        private void GetTenthFrame()
        {
            if (frames[9].Length == 3)
            {
                if (frames[9][0] == 'X' && frames[9][1] == 'X')
                {
                    scorePerFrame[9] = 20 + GetTenthFrameValue(2);
                }
                else if (frames[9][0] == 'X' && frames[9][2] == '/')
                {
                    scorePerFrame[9] = 20;
                }
                else if (frames[9][0] == 'X')
                {
                    scorePerFrame[9] = 10 + GetTenthFrameValue(1) + GetTenthFrameValue(2);
                }
                else
                {
                    scorePerFrame[9] = 10 + GetTenthFrameValue(2);
                }
            }
            else
            {
                scorePerFrame[9] = GetTenthFrameValue(0) + GetTenthFrameValue(1);
            }
        }
        private int GetTenthFrameValue(int index)
        {
            if (frames[9][index] == 'X')
            {
                return 10;
            }
            else
            {
                int roll;
                string frameTen = frames[9][index].ToString();
                int.TryParse(frameTen, out roll);
                return roll;
            }
        }
    }
}