using BowlingKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BowlingKata.FrameExtensions;

namespace BowlingKata
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
            if (i <= 7) // First to Eighth Frames
            {
                if (NextTwoFramesAreStrikes(i))
                {
                    return 20;
                }

                if (NextFrameIsStrike(i))
                {
                    return 10;
                }

                return NextFrameScore(i);
            }

            if (i == 8) // Ninth Frame
            {
                if (_frames[i + 1].FirstShot == 10 && _frames[i + 1].SecondShot == 10)
                {
                    return 20;
                }

                if (_frames[i + 1].FirstShot == 10)
                {
                    return 10;
                }

                return NextFrameScore(i);
            }

            if (i == 9) // Tenth Frame
            {
                var tenthFrame = (TenthFrame)_frames[i];
                if (tenthFrame.SecondShot == 10 && tenthFrame.ThirdShot == 10)
                {
                    return 20;
                }

                if (tenthFrame.SecondShot == 10)
                {
                    return 10;
                }

                return tenthFrame.FirstShot + tenthFrame.SecondShot + tenthFrame.ThirdShot;
            }

            return -1;
        }

        private bool NextTwoShotsAreStrikes(int i)
        {
            if (i <= 7) // First to Eighth Frames
            {
                return NextTwoFramesAreStrikes(i);
            }
            if (i == 8) // Ninth Frame
            {
                return IsDoubleInTenthFrame((TenthFrame)_frames[i + 1]);
            }
            if (i == 9) // Tenth Frame
            {
                
            }
        }

        private bool IsDoubleInTenthFrame(TenthFrame tenthFrame)
        {
            return (tenthFrame.SecondShot == 10 && tenthFrame.ThirdShot == 10);
        }

        private int NextFrameScore(int i)
        {
            return _frames[i + 1].FirstShot + _frames[i + 1].SecondShot;
        }

        private bool NextFrameIsStrike(int i)
        {
            return _frames[i + 1].IsStrike();
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
