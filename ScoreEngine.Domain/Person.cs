namespace ScoreEngine.Domain;

public class Person
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Image { get; private set; }
    public string Identificator => $"{Email}-{PhoneNumber}";

    public Person(string name, string email, string phoneNumber, string image)
    {

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException("Phone number cannot be null or empty", nameof(phoneNumber));
        }

        if (string.IsNullOrWhiteSpace(image))
        {
            throw new ArgumentException("Image cannot be null or empty", nameof(image));
        }

        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Image = image;
    }
}
