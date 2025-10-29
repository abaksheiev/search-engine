namespace ScoreEngine.Domain;

public class Review
{
    public int Rating { get; private set; }
    
    public string Text { get; private set; }
    
    public List<string> DogNames { get; private set; } = new();

    public PersonModel Sitter { get; private set; }

    public PersonModel Owner { get; private set; }

    public DateTime StartDate { get; private set; }
    
    public DateTime EndDate { get; private set; }

    public int ResponseTimeMinutes{ get; private set; }

    public Review(string strRating, string text, string responseTimeMinutes)
    {
        var rating = int.Parse(strRating);
        var responseTime = int.Parse(responseTimeMinutes);

        if (rating < 1 || rating > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5");
        }

        this.Rating = rating;
        this.Text = text;
        this.ResponseTimeMinutes = responseTime;
    }

    public Review AddOwener(string name, string email, string phoneNumber, string image)
    {
        this.Owner = new PersonModel(name, email, phoneNumber, image);

        return this;
    }

    public Review AddSitter(string name, string email, string phoneNumber, string image)
    {
        this.Sitter = new PersonModel(name, email, phoneNumber, image);

        return this;
    }

    public Review AddDates(string strStartDate, string strEndDate)
    {
        if (!DateTime.TryParse(strStartDate, out var startDate))
        {
            throw new ArgumentException("Invalid start date format", nameof(strStartDate));
        }

        if(!DateTime.TryParse(strEndDate, out var endDate))
        {
            throw new ArgumentException("Invalid end date format", nameof(strEndDate));
        }


        if (startDate > endDate)
        {
            throw new ArgumentException("Start date must be before end date");
        }

        this.StartDate = startDate;
        this.EndDate = endDate;
        return this;
    }

    public Review AddDogNames(string dogNames)
    {
        if (string.IsNullOrEmpty(dogNames))
        {
            throw new ArgumentException("Dog names cannot be null or empty", nameof(dogNames));
        }

        this.DogNames.AddRange(dogNames.Split('|'));
        return this;
    }
}
