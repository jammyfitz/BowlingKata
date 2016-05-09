using System;

namespace BowlingKata
{
    public class Frame : IFrame
    {
        public int FirstShot { get; set; }

        public int SecondShot { get; set; }
        public bool EndOfFrame { get; set; }

        public int GetScore()
        {
            return FirstShot + SecondShot;
        }

        public void SaveScore(int score)
        {
            if (FirstShot == 0)
            {
                FirstShot = score;
            }
            else
            {
                SecondShot = score;
                EndOfFrame = true;
            }
        }
    }
}
