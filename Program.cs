using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Adds Swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "PizzaStore API", Description = "Making pizzas you like"});
 }
);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
