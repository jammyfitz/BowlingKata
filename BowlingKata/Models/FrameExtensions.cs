using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public static class FrameExtensions
    {
        public static bool IsStrike(this IFrame frame)
        {
            if (frame.FirstShot == 10)
            {
                return true;
            }

            return false;
        }

        public static bool IsSpare(this IFrame frame)
        {
            if ((frame.GetScore() == 10) && !IsStrike(frame))
            {
                return true;
            }

            return false;
        }

        public static bool IsNormalFrame(this IFrame frame)
        {
                return frame is Frame;
        }

    }
}
