using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (IsSpare(_frames[i]))
                {
                    bonusScore = _frames[i + 1].FirstShot;
                }
                else if (IsStrike(_frames[i]))
                {
                    bonusScore = _frames[i + 1].FirstShot + _frames[i + 1].SecondShot;
                }

                totalScore += normalScore + bonusScore;
            }

            return totalScore;
        }

        private bool IsStrike(IFrame frame)
        {
            if (frame.FirstShot == 10)
            {
                return true;
            }

            return false;
        }

        private bool IsSpare(IFrame frame)
        {
            if ((frame.GetScore() == 10) && !IsStrike(frame))
            {
                return true;
            }

            return false;
        }
    }
}
