using ScoreEngine.Contracts.Services;
using ScoreEngine.Domain;
using ScoreEngine.Start.Model;

namespace ScoreEngine.Busness
{
    public class CaclulatorService : ICaclulatorService
    {
        private readonly IProfileService _profileService;
        private readonly ISearchService _searchService;
        private readonly IRatingService _ratingService;

        public CaclulatorService(IProfileService profileService, ISearchService searchService, IRatingService ratingService)
        {
            _profileService = profileService;
            _searchService = searchService;
            _ratingService = ratingService;
        }

        public List<SitterVisitScores> RunCalculation(List<Review> data)
        {
            var outputResult = new List<SitterVisitScores>();
           
            var sitters = data
                .Select(s=>s.Sitter)
                .GroupBy(sitter => sitter.Identificator).
                ToDictionary(d => d.Key, d => d.FirstOrDefault());

            var reviewSitters = data.GroupBy(item => item.Sitter.Identificator).ToDictionary(d => d.Key, d => d.ToList());


            foreach (var sitterId in sitters.Keys)
            {
                var item = new SitterVisitScores();

                item.SitterEmail = sitters[sitterId].Email;
                item.SitterName = sitters[sitterId].Name;

                item.ProfileScore = _profileService.CalculateProfileScore(sitters[sitterId]);
                item.RatingsScore = _ratingService.CalculateRatingsScore(reviewSitters[sitterId]);
                item.SearchScore = _searchService.CalculateSearchScore(item.ProfileScore, item.RatingsScore, reviewSitters[sitterId].Count);

                outputResult.Add(item);
            }

            return outputResult;
        }
    }
}
