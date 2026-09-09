using HomeManager.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseStaticFiles();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = "PokeData Builder";
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.InjectStylesheet("/swagger/custom.css");
});

app.MapFallbackToFile("/index.html");

app.Run();
