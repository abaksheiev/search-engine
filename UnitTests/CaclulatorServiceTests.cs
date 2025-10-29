using Moq;
using ScoreEngine.Busness;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Domain;

namespace UnitTests
{
    public class CaclulatorServiceTests
    {
        private ICaclulatorService _caclulatorService;  
        
        private Mock<IProfileService> _profileServiceMock = new();
        private Mock<ISearchService> _searchServiceMock = new();
        private Mock<IRatingService> _ratingServiceMock = new();

        public CaclulatorServiceTests()
        {
            _caclulatorService = new CaclulatorService(_profileServiceMock.Object, _searchServiceMock.Object, _ratingServiceMock.Object);
        }


        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(8)]
        [InlineData(13)]
        public void WhenCalculateResult_ThenCalculation_ShouldRunForEachReview(int countOfReviews)
        {
            List<Review> data = new List<Review>();
            for (var i = 0; i < countOfReviews; i++)
            {
                var mockReview = new Review("5", "Great service", "15")
                    .AddDates("2023-01-01", "2023-01-05")
                    .AddOwener("John Doe", "mockString", "mockString", "mockString")
                    .AddSitter($"Jane Smith-{i}", $"mockString-{i}", $"mockString-{i}", $"mockString-{i}")
                    .AddDogNames("Buddy|Max");
                data.Add(mockReview);
            }

            var score = _caclulatorService.RunCalculation(data);

            _profileServiceMock.Verify(ps => ps.CalculateProfileScore(It.IsAny<PersonModel>()), Times.Exactly(countOfReviews));
            _ratingServiceMock.Verify(rs => rs.CalculateRatingsScore(It.IsAny<List<Review>>()), Times.Exactly(countOfReviews));    
            _searchServiceMock.Verify(ss => ss.CalculateSearchScore(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>()), Times.Exactly(countOfReviews));
        }
    }
}