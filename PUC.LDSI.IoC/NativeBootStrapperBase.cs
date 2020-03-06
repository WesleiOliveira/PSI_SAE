using Microsoft.Extensions.DependencyInjection;

namespace PUC.LDSI.IoC
{
    public abstract class NativeBootStrapperBase
    {
        public static void RegisterServices(IServiceCollection services) {
            //Example
            //services.AddScoped<IClasseAppService, ClasseAppService>();
        }
    }
}
