using ScoreEngine.Contracts.Dtos;

namespace ScoreEngine.Start.Model;

public class SitterVisitScores
{
    [ColumnName("email")]
    public string SitterEmail { get; set; }
    [ColumnName("name")]
    public string SitterName { get; set; }
    [ColumnName("profile_score")]
    public double ProfileScore { get; set; }
    [ColumnName("ratings_score")]
    public double RatingsScore { get; set; }
    [ColumnName("search_score")]
    public double SearchScore { get; set; }
}
