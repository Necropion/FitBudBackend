using Microsoft.AspNetCore.Mvc;
using Backend.models;
using Backend.services;
using Backend.models.dtos;

namespace Backend.controllers;

[ApiController]
[Route("api/exercise")]
public class ExerciseController : ControllerBase
{
    private readonly ExerciseService _exerciseService;

    public ExerciseController(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    // Get All Exercises
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        var exercises = await _exerciseService.FetchAllExercises();

        return Ok(exercises);
    }

    // Get Users Exercises
    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<ExerciseResponseDTO>>> GetUsersExercises(Guid userId)
    {
        var exercises = await _exerciseService.FetchUsersExercises(userId);

        return Ok(exercises);
    }


    // Post Sinlge Exercise
    [HttpPost]
    public async Task<ActionResult<ExerciseResponseDTO>> PostExercise(ExerciseCreateDTO exerciseCreateDTO)
    {

        var newExercise = await _exerciseService.CreateExercise(exerciseCreateDTO);


        return Ok(newExercise);
    }
}