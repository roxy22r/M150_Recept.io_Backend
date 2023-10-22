using Amazon.Auth.AccessControlPolicy;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RecipeRepositories;
using RecipeRepositoriesMngoDb;
using RecipeService;
using RezeptIO.API.Configuration;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var mongoDbSettings = new MongoDBSettings();
builder.Configuration.AddJsonFile(Environment.CurrentDirectory + "\\Configuration\\appsettings.json");
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
    policy =>
    {
        policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore();



builder.Configuration.GetSection("Persistence").Bind(mongoDbSettings);


if (mongoDbSettings.Type == "mongodb")
{
    builder.Services.AddSingleton<IRecipeRepository, MngoRecipeRepository>();
    builder.Services.AddSingleton<IMongoDatabase>(x => new MongoClient(mongoDbSettings.Connectionstring).GetDatabase(mongoDbSettings.Databasename));
}
builder.Services.AddScoped<IRecipeService, RecipeService.RecipeService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseCors("_myAllowSpecificOrigins");

app.Run();
