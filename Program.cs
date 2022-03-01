using Microsoft.OpenApi.Models;

PizzaDb db = new PizzaDb();
var builder = WebApplication.CreateBuilder(args);

//Adds Swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "PizzaStore API", Description = "Making pizzas you like"});
 }
);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Store API V1");
 }
);

//app.MapGet("/", () => "Hello World!");
app.MapGet("/pizzas/{id}", (int id) => db.GetPizza(id));
app.MapGet("/pizzas", () => db.GetPizzas());
app.MapPost("/pizzas", (Pizza pizza) => db.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => db.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => db.RemovePizza(id));

app.Run();
