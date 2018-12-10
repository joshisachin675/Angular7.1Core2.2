using DotNetCore.IoC;
using IDCardScanning.Application;
using IDCardScanning.Database;
using IDCardScanning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IDCardScanning.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCriptography(Guid.NewGuid().ToString());
            services.AddHash();
            services.AddJsonWebToken(Guid.NewGuid().ToString());
            services.AddLogger(configuration);

            services.AddServices();

            var connectionString = configuration.GetConnectionString(nameof(DatabaseContext));
            services.AddDbContextEnsureCreatedMigrate<DatabaseContext>(options => options.UseSqlServer(connectionString));
        }

        private static void AddServices(this IServiceCollection services)
        {
            // IDCardScanning.Application
            services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            services.AddScoped<IFileApplication, FileApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            // IDCardScanning.Domain
            services.AddScoped<IAuthenticationDomain, AuthenticationDomain>();
            services.AddScoped<IFileDomain, FileDomain>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserLogDomain, UserLogDomain>();

            // IDCardScanning.Database
            services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
            services.AddScoped<IUserLogRepository, UserLogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
