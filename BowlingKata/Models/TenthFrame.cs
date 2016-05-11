namespace BowlingKata.Models
{
    public class TenthFrame : IFrame
    {
        public int FirstShot { get; set; }
        public int SecondShot { get; set; }
        public int ThirdShot { get; set; }
        public bool EndOfFrame { get; set; }

        public int GetScore()
        {
            if (FirstShot + SecondShot >= 10)
            {
                return FirstShot + SecondShot + ThirdShot;
            }

            return FirstShot + SecondShot;
        }

        public void SaveScore(int score)
        {
            if (FirstShot == -1)
            {
                FirstShot = score;
            }
            else if (SecondShot == -1)
            {
                SecondShot = score;
            }
            else
            {
                ThirdShot = score;
                EndOfFrame = true;
            }
        }
    }
}
