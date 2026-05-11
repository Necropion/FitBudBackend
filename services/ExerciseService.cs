using Backend.models;
using Backend.models.dtos;
using FitBudBackend.data;
using Microsoft.EntityFrameworkCore;

namespace Backend.services;

public class ExerciseService
{
    private readonly DatabaseContext _databaseContext;

    public ExerciseService(DatabaseContext context)
    {
        _databaseContext = context;
    }

    // Fetch All Exercises
    public async Task<IEnumerable<ExerciseResponseDTO>> FetchAllExercises()
    {
        var exercises = await _databaseContext.Exercises
        .Include(e => e.User)
        .Select(e => new ExerciseResponseDTO
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            Notes = e.Notes,
            User = e.User.Name,
            Created_at = e.Created_at
        })
        .ToListAsync();
        
        return exercises;
    }

    // Find Single Exercise By Id
    public async Task<ExerciseResponseDTO?> FindExerciseByID(Guid exerciseId)
    {
        var exerciseFound = await _databaseContext.Exercises
        .Include(e => e.User)
        .FirstOrDefaultAsync(e => e.Id == exerciseId);

        if (exerciseFound == null)
        {
            return null;
        }

        var exercise = new ExerciseResponseDTO
        {
            Id = exerciseFound.Id,
            Title = exerciseFound.Title,
            Description = exerciseFound.Description,
            Notes = exerciseFound.Notes,
            User = exerciseFound.User?.Name,
            Created_at = exerciseFound.Created_at
        };

        return exercise;
    }

    // Fetch All Users Exercises
    public async Task<IEnumerable<ExerciseResponseDTO?>> FetchUsersExercises(Guid userId)
    {
        var exercises = await _databaseContext.Exercises
        .Where(e => e.UserId == userId)
        .Select(e => new ExerciseResponseDTO
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            Notes = e.Notes,
            User = e.User.Name,
            Created_at = e.Created_at
        })
        .ToListAsync();

        return exercises;
    }

    // Create Exercise
    public async Task<ExerciseResponseDTO?> CreateExercise(ExerciseCreateDTO exerciseCreateDTO)
    {

        var newExercise = new Exercise
        {
            Title = exerciseCreateDTO.Title,
            Description = exerciseCreateDTO.Description,
            Notes = exerciseCreateDTO.Notes
        };

        if (exerciseCreateDTO.UserId.HasValue)
        {
            var user = await _databaseContext.Users
                .FirstOrDefaultAsync(u => u.Id == exerciseCreateDTO.UserId);

            if (user == null)
                throw new Exception("User does not exist");

            newExercise.UserId = exerciseCreateDTO.UserId;
        }

        _databaseContext.Exercises.Add(newExercise);
        await _databaseContext.SaveChangesAsync();



        return await FindExerciseByID(newExercise.Id);
    }
}