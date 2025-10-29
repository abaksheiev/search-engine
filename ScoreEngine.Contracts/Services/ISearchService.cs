namespace ScoreEngine.Contracts.Services
{
    public interface ISearchService : IBaseService
    {
        double CalculateSearchScore(double profileScore, double ratingsScore, int count);
    }
}
