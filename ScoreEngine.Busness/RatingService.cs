using ScoreEngine.Contracts.Services;
using ScoreEngine.Domain;

namespace ScoreEngine.Busness
{
    public class RatingService : IRatingService
    {
        public double CalculateRatingsScore(List<Review> reviews)
        {
           return reviews.Any() ? reviews.Average(r => r.Rating) : 0d;
        }

        public decimal GetScores()
        {
            throw new NotImplementedException();
        }
    }
}
