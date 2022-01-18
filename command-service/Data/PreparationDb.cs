using CommandService.Models;
using CommandService.SyncDataServices.Grpc;

namespace CommandService.Data
{
    public static class PreparationDb
    {
        public static void PreparePopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();
                if (grpcClient != null)
                {
                    var platforms = grpcClient.ReturnAllPlatforms();
                    ICommandRepository? commandRepository = serviceScope.ServiceProvider.GetService<ICommandRepository>();
                    if (platforms.Any() && commandRepository != null)
                    {
                        SeedData(commandRepository, platforms);                        
                    }
                }
            }
        }

        private static void SeedData(ICommandRepository repository,
            IEnumerable<Platform> platforms)
        {
            Console.WriteLine("--> Seeding new platforms...");
            foreach (var platform in platforms)
            {
                if (!repository.ExternalPlatformExists(platform.ExternalId))
                {
                    repository.CreatePlatform(platform);
                }
                repository.SaveChanges();
            }
        }
    }
}