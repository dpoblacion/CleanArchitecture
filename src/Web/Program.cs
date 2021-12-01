using Application;
using Elastic.Apm.AspNetCore;
using Infrastructure;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add logging
    builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration));

    // Add services to the container.
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllersWithViews();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // APM agent setup
    app.UseElasticApm(builder.Configuration);

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
    app.MapFallbackToFile("index.html"); ;

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception.");
}
finally
{
    Log.CloseAndFlush();
}