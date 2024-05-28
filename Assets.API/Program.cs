using Assets.Infrastructure.Extensions;
using Assets.Application.Extensions;
using Assets.Domain.Entities;
using Assets.API.Extensions;
using Assets.Infrastructure.Seeders;
using Serilog;
using Serilog.Formatting.Compact;
using Assets.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

new CompactJsonFormatter();


builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();
var scope = app.Services.CreateScope();


var seeder = scope.ServiceProvider.GetRequiredService<IAssetSeeders>();
await seeder.Seed();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TotalExecutedTimeMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();


app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.MapGroup("api/identity/")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
