using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        public int TotalScore { get; set; }
        private int FrameNumber { get; set; }
        private List<Frame> Frames { get; set; } 
        private int TotalRolls { get; set; }
        private int ShotScore { get; set; }
        private int PreviousScore { get; set; }
        public Game()
        {
            Frames = InitialiseFrames();
            FrameNumber = 1;
            TotalRolls = 1;
        }

        public void Roll(int shotScore)
        {
            SaveScore(shotScore);

            if(EndOfFrame())
            {
                FrameNumber++;
            }

            TotalRolls++;
        }

        public int Score()
        {
            return Frames.Sum(x => x.FirstShot + x.SecondShot);
        }

        private bool EndOfFrame()
        {
            return Frames[FrameNumber - 1].EndOfFrame;
        }

        private void SaveScore(int shotScore)
        {
            Frames[FrameNumber - 1].SaveScore(shotScore);
        }

        private bool IsStrike()
        {
            if (ShotScore == 10)
            {
                return true;
            }

            return false;
        }

        private bool IsSpare()
        {
            if ((ShotScore + PreviousScore == 10) && ShotScore != 0 && PreviousScore != 0)
            {
                return true;
            }

            return false;
        }
        private static List<Frame> InitialiseFrames()
        {
            return new List<Frame>(10)
            {
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame()
            };
        }
    }
}
