using Autofac;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Init;

namespace UnitTests
{
    public class RatingServiceTests
    {
        private IRatingService _ratingService;    
        public RatingServiceTests()
        {
            var container = ScoreEngineContainer.BuildContainer();
            _ratingService = container.Resolve<IRatingService>();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2d)]
        [InlineData(new int[] { 3, 2 }, 2.5d)]
        public void WhenPersonHasDublicatedChar_ThanResult_ShouldNotChanged(int[] ratings, double expectedValue)
        {
            var data = ratings.Select(r => new ScoreEngine.Domain.Review(r.ToString(), "text", "30")).ToList();

            var score = _ratingService.CalculateRatingsScore(data);
            Assert.Equal(Math.Round(expectedValue,2), Math.Round( score,2));

        }
    }
}