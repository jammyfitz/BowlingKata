using System.Collections.Generic;
using BowlingKata.Models;

namespace BowlingKata.Helpers
{
    public class ScoreHelper
    {
        private readonly List<IFrame> _frames;
        public ScoreHelper(List<IFrame> frames)
        {
            _frames = frames;
        }

        public int GetTotalScore()
        {
            var totalScore = 0;

            for (int i = 0; i < _frames.Count; i++)
            {
                var normalScore = _frames[i].GetScore();
                var bonusScore = 0;

                if (_frames[i].IsSpare())
                {
                    bonusScore = GetSpareBonusScore(i);
                }
                else if (_frames[i].IsStrike())
                {
                    bonusScore = GetStrikeBonusScore(i);
                }

                totalScore += normalScore + bonusScore;
            }

            return totalScore;
        }

        private int GetStrikeBonusScore(int i)
        {
            if (NextTwoShotsAreStrikes(i))
            {
                return 20;
            }

            if (NextShotIsStrike(i))
            {
                return 10;
            }

            return NextShotScore(i);
        }

        private bool NextTwoShotsAreStrikes(int i)
        {
            switch (i)
            {
                case 8:
                    return IsDoubleStrikeInTenthFrame((TenthFrame)_frames[i + 1]);
                case 9:
                    return false;
                default:
                    return NextTwoFramesAreStrikes(i);
            }
        }

        private static bool IsDoubleStrikeInTenthFrame(TenthFrame tenthFrame)
        {
            return (tenthFrame.FirstShot == 10 && tenthFrame.SecondShot == 10);
        }

        private int NextShotScore(int i)
        {
            if (LastFrame(i))
            {
                return 0;
            }

            return _frames[i + 1].FirstShot + _frames[i + 1].SecondShot;
        }

        private static bool LastFrame(int i)
        {
            return i == 9;
        }

        private bool NextShotIsStrike(int i)
        {
            if (LastFrame(i))
            {
                return false;
            }

            return _frames[i + 1].FirstShot == 10;
        }

        private bool NextTwoFramesAreStrikes(int i)
        {
            return _frames[i + 1].IsStrike() && _frames[i + 2].IsStrike();
        }

        private int GetSpareBonusScore(int i)
        {
            return _frames[i + 1].FirstShot;
        }
    }
}
