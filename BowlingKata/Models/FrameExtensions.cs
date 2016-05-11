namespace BowlingKata.Models
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
    }
}
