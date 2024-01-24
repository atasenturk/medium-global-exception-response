using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ResponseModelWebApi.Repositories.GenericRepository;
using ResponseModelWebApi.Repositories.Interfaces;
using ResponseModelWebApi.Repositories;
using ResponseModelWebApi.Services;
using ResponseModelWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ResponseModelWebApi.Extensions;

public static class Registration
{
    public static IServiceCollection AddContextRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ResponseModelWebApiContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ResponseModelDbConnStr"));
        });
        return services;
    }

    public static IServiceCollection AddRepositoriesRegistration(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<DbContext, ResponseModelWebApiContext>();
        return services;
    }

    public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AuthConfig:Secret"]));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey
                };
            });

        return services;
    }
}