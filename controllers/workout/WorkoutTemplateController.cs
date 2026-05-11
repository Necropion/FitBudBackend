using Microsoft.AspNetCore.Mvc;
using Backend.models;
using Backend.services;
using Backend.models.dtos;

namespace Backend.controllers;

[ApiController]
[Route("api/workout")]
public class WorkoutController : ControllerBase
{
    private readonly WorkoutTemplateService _workoutTemplateService;

    public WorkoutController(WorkoutTemplateService workoutTemplateService)
    {
        _workoutTemplateService = workoutTemplateService;
    }

    // Get All Workout Templates
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutTemplateResponseDTO>>> GetAllWorkoutTemplates()
    {
        var workoutTemplates = await _workoutTemplateService.FetchAllWorkoutTemplates();

        return Ok(workoutTemplates);
    }

    // Post Workout Template
    [HttpPost]
    public async Task<ActionResult<WorkoutTemplateResponseDTO>> PostWorkoutTemplate(WorkoutTemplateCreateDTO dto)
    {
        var newWorkoutTemplate = await _workoutTemplateService.CreateWorkoutTemplate(dto);

        return Ok(newWorkoutTemplate);
    }
}