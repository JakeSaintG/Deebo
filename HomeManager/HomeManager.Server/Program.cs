using System.Data.Common;
using HomeManager.Server.Models;
using HomeManager.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HomeManagerContext>();

builder.Services.AddScoped<Func<HomeManagerContext>>(_ => DbContextFactory.Create);
builder.Services.AddScoped<UserService>();

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using var dbContext = DbContextFactory.Create();
    dbContext.Database.EnsureCreated();
    // dbContext.Database.Migrate();
}

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
