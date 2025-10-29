using ScoreEngine.Contracts.Repository;
using ScoreEngine.Domain;
using ScoreEngine.Repositories.Enums;

namespace ScoreEngine.Repositories
{
    public class FileRepository : IDataRepository
    {
        private string[] _delimiter = [",",";"];

        public List<Review> ReadData(string filePath)
        {
            var fileExists = File.Exists(filePath);
           
            if (!fileExists)
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }

            var data = new List<Review>();

            var lines = File.ReadLines(filePath);

            var isHeaderPassed = false;
            foreach (var line in lines)
            {
                // Skip header line
                if (!isHeaderPassed)
                {
                    isHeaderPassed = true;
                    continue;
                }

                var parts = line.Split(_delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var singleReview = new Review(parts[Columns.Rating], parts[Columns.Text], parts[Columns.ResponseTimeMinutes])
                    .AddDates(parts[Columns.StartDate], parts[Columns.EndDate])
                    .AddOwener(parts[Columns.Owner], parts[Columns.OwnerEmail], parts[Columns.OwnerPhoneNumber], parts[Columns.OwnerImage])
                    .AddSitter(parts[Columns.Sitter], parts[Columns.SitterEmail], parts[Columns.SitterPhoneNumber], parts[Columns.SitterImage])
                    .AddDogNames(parts[Columns.Dogs])
                    ;

                data.Add(singleReview);
            }
           
            return data;
        }
    }
}
