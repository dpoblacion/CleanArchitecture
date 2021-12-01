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
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // APM agent setup
    app.UseElasticApm(builder.Configuration);

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

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