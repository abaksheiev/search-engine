using ScoreEngine.Contracts.Services;
using ScoreEngine.Domain;

namespace ScoreEngine.Busness;

public class ProfileService : IProfileService
{
    private const double Koeficient = 5d;
    private const int TotalEnglishLetters = 26;

    public double CalculateProfileScore(Person person)
    {
        var letters = new HashSet<char>();
        foreach (var c in person.Name)
        {
            if (char.IsLetter(c))
            {
                letters.Add(char.ToLower(c));
            }
        }

        return Koeficient * letters.Count / TotalEnglishLetters;
    }
}
