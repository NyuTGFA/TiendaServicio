using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.api.usuarios.Interfaces;
using TiendaServicio.api.usuarios.Services;
using TiendaServicio.api.usuarios.Data;

namespace TiendaServicio.api.usuarios.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services , IConfiguration configuration) {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

    }
    }

