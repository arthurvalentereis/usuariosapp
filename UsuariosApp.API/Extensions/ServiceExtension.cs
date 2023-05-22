using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Infra.Data.Contexts;
using UsuarioApp.Infra.Data.Repositories;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Services;
using UsuariosApp.Domain.Services;

namespace UsuariosApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DataContext>();
            return services;
        }
    }
}