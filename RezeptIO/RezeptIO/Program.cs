using MongoDB.Driver;
using RecipeRepositories;
using RecipeRepositoriesMngoDb;
using RecipeService;
using RezeptIO.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
var mongoDbSettings = new MongoDBSettings();
var configDir = Environment.GetEnvironmentVariable("CONFIG_DIR");

builder.Configuration.AddJsonFile(Environment.CurrentDirectory + configDir);

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

builder.Services.AddScoped<IRecipeService, RecipeService.RecipeService>();

builder.Configuration.GetSection("Persistence").Bind(mongoDbSettings);


if (mongoDbSettings.Type == "mongodb")
{
    builder.Services.AddSingleton<IRecipeRepositoriesMngoDb, MngoRecipeRepository>();
    builder.Services.AddSingleton<IMongoDatabase>(x => new MongoClient(mongoDbSettings.Connectionstring).GetDatabase(mongoDbSettings.Databasename));
}

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseCors("_myAllowSpecificOrigins");

app.Run();
