using ScoreEngine.Domain;

namespace ScoreEngine.Contracts.Services;

public interface IProfileService : IBaseService
{
    double CalculateProfileScore(PersonModel reviews);
}
