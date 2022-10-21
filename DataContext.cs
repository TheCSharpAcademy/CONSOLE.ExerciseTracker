using ExerciseTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Api;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; set; } = null!;
}
