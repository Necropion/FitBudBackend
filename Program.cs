using Npgsql;
using Microsoft.EntityFrameworkCore;
using FitBudBackend.data;
using Backend.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connString));

// Dependency Injections
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<WeightUnitService>();

try
{

    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    Console.WriteLine("Connected to the database successfully");

    conn.Close();
} catch (Exception ex)
{
    Console.WriteLine("Failed to connect");
    Console.WriteLine(ex.Message);
}

var app = builder.Build();

// Run Database Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    
    Console.WriteLine("Applying migrations...");
    db.Database.Migrate();
    Console.WriteLine("Migrations applied.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
