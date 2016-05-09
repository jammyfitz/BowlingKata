using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        public int TotalScore { get; set; }
        private int FrameNumber { get; set; }
        private List<IFrame> Frames { get; set; } 
        private int TotalRolls { get; set; }
        private int ShotScore { get; set; }

        private readonly ScoreHelper ScoreHelper;
        public Game()
        {
            Frames = InitialiseFrames();
            FrameNumber = 1;
            TotalRolls = 1;
            ScoreHelper = new ScoreHelper(Frames);
        }

        public void Roll(int shotScore)
        {
            SaveScore(shotScore);

            if(IsEndOfFrame())
            {
                FrameNumber++;
            }

            TotalRolls++;
        }

        public int Score()
        {
            return ScoreHelper.GetTotalScore();

            
        }

        private bool IsEndOfFrame()
        {
            return Frames[FrameNumber - 1].EndOfFrame;
        }

        private void SaveScore(int shotScore)
        {
            Frames[FrameNumber - 1].SaveScore(shotScore);
        }


        private static List<IFrame> InitialiseFrames()
        {
            return new List<IFrame>(10)
            {
                new Frame()
                {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new Frame()  {
                    FirstShot = -1,
                    SecondShot = -1
                },
                new TenthFrame()
                {
                    FirstShot = -1,
                    SecondShot = -1,
                    ThirdShot = -1
                }
            };
        }
    }
}
