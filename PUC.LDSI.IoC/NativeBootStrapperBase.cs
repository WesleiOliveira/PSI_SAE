using Microsoft.Extensions.DependencyInjection;
using PUC.LDSI.Application.AppServices;
using PUC.LDSI.Application.Interfaces;
using PUC.LDSI.DataBase.Repository;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Domain.Interfaces.Services;
using PUC.LDSI.Domain.Services;

namespace PUC.LDSI.IoC
{
    public abstract class NativeBootStrapperBase
    {
        public readonly IAlunoRepository AlunoRepository;
        public readonly IProfessorRepository ProfessorRepository;
        public static void RegisterServices(IServiceCollection services) {
            
            services.AddScoped<IAlunoRepository, AlunoRepository>();

            services.AddScoped<IProfessorAppService, ProfessorAppService>();

            services.AddScoped<ITurmaAppService, TurmaAppService>();
            
            //Application
            services.AddScoped<ITurmaAppService, TurmaAppService>();

            //Domain - Repository
            services.AddScoped<ITurmaRepository, TurmaRepository>();

            //Domain - Services
            services.AddScoped<ITurmaService, TurmaService>();
        }
    }
}
