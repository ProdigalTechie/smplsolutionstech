using SmplSolutionsTech.Logic;

namespace SmplSolutionsTech.Extentions
{
    public static class LogicServiceExt
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddScoped<IGeneratorLogic, GeneratorLogic>();

            return services;
        }
    }

}
