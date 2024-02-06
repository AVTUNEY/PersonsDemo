var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices();

var supportedCultures = new[]
{
    new CultureInfo("ka-GE"),
    new CultureInfo("en-US")
};

var localizationOptions = new RequestLocalizationOptions()
{
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    ApplyCurrentCultureToResponseHeaders = true
};
localizationOptions.SetDefaultCulture("en-US");

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TbcDemoDbContext>();
    db.Database.EnsureDeleted();
    if (!db.Database.CanConnect())
    {
        db.Database.Migrate();
    }
}

app.Run();