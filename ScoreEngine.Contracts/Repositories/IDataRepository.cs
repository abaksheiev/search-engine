using ScoreEngine.Domain;

namespace ScoreEngine.Contracts.Repository;

public interface IDataRepository
{
    List<Review> ReadData(string filePath);
}
