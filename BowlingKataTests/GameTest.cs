namespace BowlingKataTests
{
    using BowlingKata;
    using NUnit.Framework;

    [TestFixture]
    public class GameTest
    {
        [Test]
        public void GutterGameScoresZero()
        {
            Game game = new Game();

            for (int i = 1; i <= 20; i++)
            {
                game.Roll(0);
            }

            Assert.That(game.Score() == 0);
        }

        [Test]
        public void AllOnesScoreTwenty()
        {
            Game game = new Game();

            for (int i = 1; i <= 20; i++)
            {
                game.Roll(1);
            }

            Assert.That(game.Score() == 20);
        }

        [Test]
        public void ASpareThenThreePinsThenAllMissesScoresSixteen()
        {
            Game game = new Game();


            //Spare
            game.Roll(5);
            game.Roll(5);

            game.Roll(3);
            game.Roll(0);

            for (int i = 1; i <= 16; i++)
            {
                game.Roll(0);
            }

            Assert.That(game.Score() == 16);
        }

    }
}
