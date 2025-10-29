using Autofac;
using ScoreEngine.Contracts.Repository;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Init;
using ScoreEngine.Start.Model;

namespace ScoreEngine
{
    internal class Program
    {
        static private string PathToFileDefault { get; set; } = "Data/reviews.csv";
        static private string OutputFileDefault { get; set; } = "Data/sitters.csv";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");

            var container = ScoreEngineContainer.BuildContainer();

            // Read Data
            var repository = container.Resolve<IDataRepository>();
            var data = repository.ReadData(PathToFileDefault);

            // Calculate Scores
            var calculateService = container.Resolve<ICaclulatorService>();
            var scores = calculateService.RunCalculation(data);

            // Output Results
            var outputService = container.Resolve<IOutputService<SitterVisitScores>>();
            outputService.OutputResults(scores, OutputFileDefault);
        }
    }
}
