using ExerciseTracker.Api;
using ExerciseTracker.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Exercises; Integrated Security=true;"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
