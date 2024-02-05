using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Presentation;

namespace TBCDemo.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });
        services.AddTransient<ExceptionHandlingMiddleware>();

        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
       
        var connectionString = ConnectionStringHelper.Get();
        services.AddDbContext<TbcDemoDbContext>(options => options.UseSqlServer(connectionString));
        services.AddControllers()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new ValidationFailedResult(context.ModelState);

                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                    return result;
                };
            });;
        
        return services;
    }
}