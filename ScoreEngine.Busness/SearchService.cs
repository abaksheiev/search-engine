using ScoreEngine.Contracts.Services;
namespace ScoreEngine.Busness;

public class SearchService : ISearchService
{
    public double CalculateSearchScore(double profileScore, double ratingsScore, int count)
    {
        if (count == 0)
        {
            return profileScore;
        }

        if (count >= 10)
        {
            return ratingsScore;
        }

        var step = (ratingsScore - profileScore) / 10;

        return profileScore + step * count;
    }
}
