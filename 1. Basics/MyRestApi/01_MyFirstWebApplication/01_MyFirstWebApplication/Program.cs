using Microsoft.EntityFrameworkCore;
using _01_MyFirstWebApplication.Data;
using _01_MyFirstWebApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// EF Core mit SQLite einbinden
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite("Data Source=schule.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHosts", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAllHosts");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// --- API-Endpunkte für Schularbeit ---
app.MapPost("/schularbeiten", async (Schularbeit schularbeit, MyDbContext db) =>
{
    db.Schularbeiten.Add(schularbeit);
    await db.SaveChangesAsync();
    return Results.Created($"/schularbeiten/{schularbeit.Id}", schularbeit);
});

app.MapGet("/schularbeiten", async (MyDbContext db) =>
{
    var list = await db.Schularbeiten.ToListAsync();
    return Results.Ok(list);
});

app.Run();