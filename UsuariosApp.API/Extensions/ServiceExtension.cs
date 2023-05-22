using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Infra.Data.Contexts;
using UsuarioApp.Infra.Data.Repositories;
using UsuariosApp.Application.Interfaces.Producers;
using UsuariosApp.Application.Interfaces.Services;
using UsuariosApp.Application.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Messages.Producers;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessageSettings>(configuration.GetSection("MessageSettings"));

            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioMessageProducer, UsuarioMessageProducer>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<DataContext>();
            return services;
        }
    }
}