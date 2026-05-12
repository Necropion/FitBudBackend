using Backend.models;
using Backend.models.dtos;
using FitBudBackend.data;
using Microsoft.EntityFrameworkCore;

namespace Backend.services;

public class WorkoutTemplateExerciseService
{
    private readonly DatabaseContext _databaseContext;

    public WorkoutTemplateExerciseService(DatabaseContext context)
    {
        _databaseContext = context;
    }

    // Fetch All Workout Template Exercises
    public async Task<IEnumerable<WorkoutTemplateExerciseResponseDTO>> FetchAllWorkoutTemplateExercises()
    {
        var workoutTemplateExercises = await _databaseContext.WorkoutTemplateExercises
        .Include(wte => wte.WorkoutTemplate)
        .Include(wte => wte.Exercise)
            .ThenInclude(e => e.User)
        .Select(wte => new WorkoutTemplateExerciseResponseDTO
        {
            Id = wte.Id,
            WorkoutTemplate = wte.WorkoutTemplate.Title,
            Exercise = new ExerciseResponseDTO
            {
                Id = wte.Exercise.Id,
                Title = wte.Exercise.Title,
                Description = wte.Exercise.Description,
                Notes = wte.Exercise.Notes,
                User = wte.Exercise.User.Name,
                Created_at = wte.Exercise.Created_at
            },
            Order = wte.Order,
            Sets = wte.Sets,
            Reps = wte.Reps,
            Created_at = wte.Created_at,
            Finished_at = wte.Finished_at
        })
        .ToListAsync();

        return workoutTemplateExercises;
    }

    // Find Single Workout Template Exercise By Id
    public async Task<WorkoutTemplateExerciseResponseDTO?> FindWorkoutTemplateExerciseById(
        Guid workoutTemplateExerciseId
    )
    {
        var workoutTemplateExerciseFound = await _databaseContext.WorkoutTemplateExercises
        .Include(wte => wte.WorkoutTemplate)
        .Include(wte => wte.Exercise)
            .ThenInclude(e => e.User)
        .FirstOrDefaultAsync(wte => wte.Id == workoutTemplateExerciseId);

        if (workoutTemplateExerciseFound == null)
        {
            return null;
        }

        var workoutTemplateExercise = new WorkoutTemplateExerciseResponseDTO
        {
            Id = workoutTemplateExerciseFound.Id,
            WorkoutTemplate = workoutTemplateExerciseFound.WorkoutTemplate.Title,
            Exercise = new ExerciseResponseDTO
            {
                Id = workoutTemplateExerciseFound.Exercise.Id,
                Title = workoutTemplateExerciseFound.Exercise.Title,
                Description = workoutTemplateExerciseFound.Exercise.Description,
                Notes = workoutTemplateExerciseFound.Exercise.Notes,
                User = workoutTemplateExerciseFound.Exercise.User?.Name,
                Created_at = workoutTemplateExerciseFound.Exercise.Created_at
            },
            Order = workoutTemplateExerciseFound.Order,
            Sets = workoutTemplateExerciseFound.Sets,
            Reps = workoutTemplateExerciseFound.Reps,
            Created_at = workoutTemplateExerciseFound.Created_at,
            Finished_at = workoutTemplateExerciseFound.Finished_at
        };

        return workoutTemplateExercise;
    }

    // Create Workout Template Exercise
    public async Task<WorkoutTemplateExerciseResponseDTO?> CreateWorkoutTemplateExercise(
        WorkoutTemplateExerciseCreateDTO dto
        )
    {
        var newWorkoutTemplateExercise = new WorkoutTemplateExercise
        {
            Order = dto.Order,
            Sets = dto.Sets,
            Reps = dto.Reps
        };

        if (dto.WorkoutTemplateId != Guid.Empty)
        {
            var workoutTemplate = await _databaseContext.WorkoutTemplates
                .FirstOrDefaultAsync(wt => wt.Id == dto.WorkoutTemplateId);

            if (workoutTemplate == null)
                throw new Exception("Workout Template does not exist");

            newWorkoutTemplateExercise.WorkoutTemplateId = dto.WorkoutTemplateId;
        }

        if (dto.ExerciseId != Guid.Empty)
        {
            var exercise = await _databaseContext.Exercises
                .FirstOrDefaultAsync(e => e.Id == dto.ExerciseId);

            if (exercise == null)
                throw new Exception("Exercise does not exist");

            newWorkoutTemplateExercise.ExerciseId = dto.ExerciseId;
        }

        _databaseContext.WorkoutTemplateExercises.Add(newWorkoutTemplateExercise);
        await _databaseContext.SaveChangesAsync();

        return await FindWorkoutTemplateExerciseById(newWorkoutTemplateExercise.Id);
    }
}