using Microsoft.OpenApi.Models;
using System.Reflection;

namespace UsuariosApp.API.Extensions
{
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UsuárioAPP - API - Treinamento Infis",
                    Description = " API para controlde de usuários",
                    Version = "v1", 
                    Contact = new OpenApiContact
                    {
                        Name = "Test",
                        Email = "contato@cotiinformatica.com",
                        Url = new Uri("https://www.cotiinformatica.com.br")
                    }
                });
                //Jogar no arquivo do swagger os comentários da api
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }
        public static IApplicationBuilder UseSwaggeDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosApp.API");
            });

            return app;
        }
    }
}
