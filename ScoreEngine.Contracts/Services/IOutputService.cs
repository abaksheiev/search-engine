namespace ScoreEngine.Contracts.Services
{
    public interface IOutputService<T> where T: new()
    {
        void OutputResults(List<T> data, string pathToFile);
    }
}
