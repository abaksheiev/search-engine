using Autofac;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Init;

namespace UnitTests
{
    public class ProfileServiceTests
    {
        private IProfileService _profileService;    
        public ProfileServiceTests()
        {
            var container = ScoreEngineContainer.BuildContainer();
            _profileService = container.Resolve<IProfileService>();
        }

        [Theory]
        [InlineData("Alice", 0.961538461538461)]
        [InlineData("AliceAlice", 0.961538461538461)]
        [InlineData("AliceAliceAlice", 0.961538461538461)]
        public void WhenPersonHasDublicatedChar_ThanResult_ShouldNotChanged(string name, double expectedValue)
        {
            var person = new ScoreEngine.Domain.PersonModel(name, "email", "phone", "image");

            var score = _profileService.CalculateProfileScore(person);
            Assert.Equal(Math.Round(expectedValue,2), Math.Round( score,2));

        }
    }
}