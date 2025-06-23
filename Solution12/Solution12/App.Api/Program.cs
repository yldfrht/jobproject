using App.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencies(builder.Configuration); //added dependencies

builder.Services.AddHttpClient("ProductClient", client =>
{
    client.BaseAddress = new Uri("https://www.example.com/api/products");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddHttpClient("CategoryClient", client =>
{
    client.BaseAddress = new Uri("https://www.example.com/api/categories");
    client.DefaultRequestHeaders.Add("Accept", "applicaton/json");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("Cors");

app.Run();
