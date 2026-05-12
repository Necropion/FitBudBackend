using Microsoft.AspNetCore.Mvc;
using Backend.models;
using Backend.services;
using Backend.models.dtos;

namespace Backend.controllers;

[ApiController]
[Route("api/workout-template-exercise")]
public class WorkoutTemplateExerciseController : ControllerBase
{
    private readonly WorkoutTemplateExerciseService _workoutTemplateExerciseService;

    public WorkoutTemplateExerciseController(
        WorkoutTemplateExerciseService workoutTemplateExerciseService
        )
    {
        _workoutTemplateExerciseService = workoutTemplateExerciseService;
    }

    // Get All Workout Template Exercises
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutTemplateExerciseResponseDTO>>> GetWorkoutTemplateExercises()
    {
        var workoutTemplateExercises = await _workoutTemplateExerciseService
            .FetchAllWorkoutTemplateExercises();

        return Ok(workoutTemplateExercises);
    }

    // Post Single Workout Template Exercise
    [HttpPost]
    public async Task<ActionResult<WorkoutTemplateCreateDTO>> PostWorkoutTemplateExercise(
        WorkoutTemplateExerciseCreateDTO dto
        )
    {

        var newWorkoutTemplateExercise = await _workoutTemplateExerciseService
                .CreateWorkoutTemplateExercise(dto);


        return Ok(newWorkoutTemplateExercise);
    }
}