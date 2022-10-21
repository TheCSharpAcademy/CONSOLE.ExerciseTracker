using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.Api.Models;

public class Exercise
{
    public int Id { get; set; }
    [Required]
    [StringLength(20)]

    public string Name { get; set; }
    [Required]
    [StringLength(20)]

    public string Sets { get; set; }

    [Required]
    [StringLength(20)]
    public string Load { get; set; }
}
