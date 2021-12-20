using ExerciseTracker.Api.Models;

namespace ExerciseTracker.Api.Repositories
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAll();
        Exercise GetById(int id);
        void Add(Exercise exercise);
        void Delete(Exercise exercise);
        void Update(Exercise exercise);
        bool Save();
    }
    public class ExerciseRepository: IExerciseRepository
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(Exercise));
            }

            _context.Exercises.Add(exercise);
        }

        public void Delete(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _context.Exercises
            .OrderBy(s => s.Id)
            .ToList();
        }

        public Exercise GetById(int id)
        {
            return _context.Exercises.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
