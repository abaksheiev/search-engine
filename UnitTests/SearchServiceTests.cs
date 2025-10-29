using Autofac;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Init;

namespace UnitTests
{
    public class SearchServiceTests
    {
        private ISearchService _searchService;    
        public SearchServiceTests()
        {
            var container = ScoreEngineContainer.BuildContainer();
            _searchService = container.Resolve<ISearchService>();
        }

        [Theory]
        [InlineData(2.5d, 5.0, 0, 2.5d)]
        [InlineData(2.5d, 5.0, 1, 2.75d)]
        [InlineData(2.5d, 5.0, 2, 3.0d)]
        [InlineData(2.5d, 5.0, 3, 3.25d)]
        [InlineData(2.5d, 5.0, 4, 3.5d)]
        [InlineData(2.5d, 5.0, 5, 3.75d)]
        [InlineData(2.5d, 5.0, 6, 4.0d)]
        [InlineData(2.5d, 5.0, 7, 4.25d)]
        [InlineData(2.5d, 5.0, 8, 4.5d)]
        [InlineData(2.5d, 5.0, 9, 4.75d)]
        [InlineData(2.5d, 5.0, 10, 5.0d)]
        [InlineData(2.5d, 5.0, 11, 5.0d)]
        [InlineData(2.5d, 5.0, 12, 5.0d)]
        [InlineData(2.5d, 5.0, 13, 5.0d)]

        public void ValidateCalculation(double profileScore, double ratingScore, int stayCount, double expectedValue)
        {
            var score = _searchService.CalculateSearchScore(profileScore, ratingScore, stayCount);
            Assert.Equal(Math.Round(expectedValue,2), Math.Round(score,2));
        }
    }
}