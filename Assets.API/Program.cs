using Assets.Infrastructure.Extensions;
using Assets.Application.Extensions;
using Assets.Domain.Entities;
using Assets.API.Extensions;
using Assets.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration)=> configuration
.MinimumLevel.Override("Microsoft",LogEventLevel.Warning).WriteTo.Console()
.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
.WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}|{NewLine}{Message:lj}{NewLine}{Exception}")
);


var app = builder.Build();


var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IAssetSeeders>();
await seeder.Seed();


app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.MapGroup("api/identity/").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
