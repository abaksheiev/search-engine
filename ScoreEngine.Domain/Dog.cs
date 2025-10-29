namespace ScoreEngine.Domain;

public class Dog
{
    public string Name { get; private set; }
    public Dog(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Dog name cannot be null or empty", nameof(name));
        }
        Name = name;
    }
}
