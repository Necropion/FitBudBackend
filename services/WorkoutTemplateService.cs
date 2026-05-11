using Backend.models;
using Backend.models.dtos;
using FitBudBackend.data;
using Microsoft.EntityFrameworkCore;

namespace Backend.services;

public class WorkoutTemplateService
{
    private readonly DatabaseContext _databaseContext;

    public WorkoutTemplateService(DatabaseContext context)
    {
        _databaseContext = context;
    }

    // Fetch All Workout Templates
    public async Task<IEnumerable<WorkoutTemplateResponseDTO>> FetchAllWorkoutTemplates()
    {
        var workoutTemplates = await _databaseContext.WorkoutTemplates
            .Include(wt => wt.User)
            .Select(wt => new WorkoutTemplateResponseDTO
            {
                Id = wt.Id,
                Title = wt.Title,
                Notes = wt.Notes,
                User = wt.User.Name,
                Created_at = wt.Created_at
            })
            .ToListAsync();

        return workoutTemplates;
    }

    // Find Single Workout Template By Id
    public async Task<WorkoutTemplateResponseDTO?> FetchSingleWorkoutTemplateById(
        Guid workoutTemplateId
        )
    {
        var workoutTemplateFound = await _databaseContext.WorkoutTemplates
        .Include(wt => wt.User)
        .FirstOrDefaultAsync(wt => wt.Id == workoutTemplateId);

        if (workoutTemplateFound == null)
        {
            return null;
        }

        var workoutTemplate = new WorkoutTemplateResponseDTO
        {
            Id = workoutTemplateFound.Id,
            Title = workoutTemplateFound.Title,
            Description = workoutTemplateFound.Description,
            Notes = workoutTemplateFound.Notes,
            User = workoutTemplateFound.User?.Name,
            Created_at = workoutTemplateFound.Created_at
        };

        return workoutTemplate;
    }

    // Create Workout
    public async Task<WorkoutTemplateResponseDTO?> CreateWorkoutTemplate(
        WorkoutTemplateCreateDTO workoutTemplateCreateDTO
        )
    {
        var newWorkoutTemplate = new WorkoutTemplate
        {
            Title = workoutTemplateCreateDTO.Title,
            Description = workoutTemplateCreateDTO.Description,
            Notes = workoutTemplateCreateDTO.Notes
        };

        if (workoutTemplateCreateDTO.UserId.HasValue)
        {
            var user = await _databaseContext.Users
                .FirstOrDefaultAsync(u => u.Id == workoutTemplateCreateDTO.UserId);

            if (user == null)
                throw new Exception("User does not exist");

            newWorkoutTemplate.UserId = workoutTemplateCreateDTO.UserId;
        }

        _databaseContext.WorkoutTemplates.Add(newWorkoutTemplate);
        await _databaseContext.SaveChangesAsync();



        return await FetchSingleWorkoutTemplateById(newWorkoutTemplate.Id);
    }
}