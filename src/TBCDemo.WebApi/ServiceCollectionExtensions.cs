namespace TBCDemo.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });

        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        var connectionString = ConnectionStringHelper.Get();
        services.AddDbContext<TbcDemoDbContext>(options => options.UseSqlServer(connectionString));
        services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

        return services;
    }
}