using ScoreEngine.Domain;

namespace ScoreEngine.Contracts.Services;

public interface IRatingService : IBaseService
{
    double CalculateRatingsScore(List<Review> reviews);
}
