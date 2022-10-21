#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Api.Models;
using ExerciseTracker.Api.Repositories;

namespace ExerciseTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExercisesController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    // GET: api/Exercises
    [HttpGet]
    public ActionResult<IEnumerable<Exercise>>GetExercises()
    {
        return Ok(_exerciseRepository.GetAll());
    }

    // GET: api/Exercises/5
    [HttpGet("{id}")]
    public ActionResult<Exercise> GetExercise(int id)
    {
        var exercise = _exerciseRepository.GetById(id);

        if (exercise == null)
        {
            return NotFound();
        }

        return Ok(exercise);
    }

    // PUT: api/Exercises/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public IActionResult PutExercise(int id, Exercise exercise)
    {
        if (id != exercise.Id)
        {
            return BadRequest();
        }

        try
        {
            _exerciseRepository.Update(exercise);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExerciseExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Exercises
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Exercise> PostExercise(Exercise exercise)
    {
        _exerciseRepository.Add(exercise);

        return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
    }

    // DELETE: api/Exercises/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExercise(int id)
    {
        var exercise = GetExercise(id);

        if (exercise == null)
        {
            return NotFound();
        }
        _exerciseRepository.Delete(exercise.Value);

        return NoContent();
    }

    private bool ExerciseExists(int id)
    {
        return GetExercise(id) != null;
    }
}
