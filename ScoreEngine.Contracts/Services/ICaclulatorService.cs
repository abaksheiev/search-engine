using ScoreEngine.Domain;
using ScoreEngine.Start.Model;

namespace ScoreEngine.Contracts.Services;

public interface ICaclulatorService
{
    List<SitterVisitScores> RunCalculation(List<Review> data);
}
