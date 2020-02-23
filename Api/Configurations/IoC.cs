using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static class IoC
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMusicaService, MusicasService>();
        }
    }
}
