using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MottuAPI.Application.Interfaces;
using MottuAPI.Application.Services;
using MottuAPI.Infrastructure.Data;

namespace MottuAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do DbContext com Oracle
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Registrar serviços
            services.AddScoped<IMotoService, MotoService>();
            services.AddScoped<IPatioService, PatioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAreaPatioService, AreaPatioService>();
            services.AddScoped<IVagaService, VagaService>();

            return services;
        }
    }
}
