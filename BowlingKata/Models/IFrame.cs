namespace BowlingKata.Models
{
    public interface IFrame
    {
        void SaveScore(int score);
        int GetScore();
        int FirstShot { get; set; }
        int SecondShot { get; set; }
        bool EndOfFrame { get; set; }
    }
}