using Autofac;
using ScoreEngine.Busness;
using ScoreEngine.Contracts.Repository;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Repositories;
using ScoreEngine.Start.Model;

namespace ScoreEngine.Init;

public static class ScoreEngineContainer
{
    public static IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();

        // Register services and their interfaces
        builder.RegisterType<ProfileService>().As<IProfileService>();
        builder.RegisterType<RatingService>().As<IRatingService>();
        builder.RegisterType<SearchService>().As<ISearchService>();

        builder.RegisterType<CaclulatorService>().As<ICaclulatorService>();
        builder.RegisterType<FileRepository>().As<IDataRepository>();
        builder.RegisterType<OutputFileService>().As<IOutputService<SitterVisitScores>>();
        
        return builder.Build();
    }
}
    
