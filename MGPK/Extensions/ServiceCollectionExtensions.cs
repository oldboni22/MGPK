﻿using Microsoft.EntityFrameworkCore;
using Repository;
using Serilog;
using Service;

namespace MGPK.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection collection,IConfiguration configuration)
    {
        collection.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }

    public static void ConfigureRepositoryManager(this IServiceCollection collection)
    {
        collection.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection collection)
    {
        collection.AddScoped<IServiceManager, ServiceManager>();
    }
    
}