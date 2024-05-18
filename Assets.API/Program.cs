using Assets.Infrastructure.Extensions;
using Assets.Application.Extensions;
using Assets.Infrastructure.Seeders;
using Assets.Domain.Entities;
using Assets.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IAssetSeeders>();
await seeder.Seed();


  app.UseSwagger();
  app.UseSwaggerUI();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGroup("api/identity/").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
