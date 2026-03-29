using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add MovieDbContext
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite("Data Source=MoviesApp.db"));

// Register Repository
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();