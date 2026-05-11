using Microsoft.AspNetCore.Mvc;
using Backend.models;
using Backend.services;

namespace Backend.controllers;

[ApiController]
[Route("api/weight-unit")]
public class WeightUnitController : ControllerBase
{
    private readonly WeightUnitService _weightUnitService;

    public WeightUnitController(WeightUnitService weightUnitService)
    {
        _weightUnitService = weightUnitService;
    }

    // Get Weight Unit List
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeightUnit>>> GetWeightUnits()
    {
        var weightUnits = await _weightUnitService.FetchAllWeightUnits();

        return Ok(weightUnits);
    }

    // Post Weight Unit
    [HttpPost]
    public async Task<ActionResult<WeightUnit>> PostWeightUnit(WeightUnit weightUnit)
    {
        var newWeightUnit = await _weightUnitService.CreateWeightUnit(weightUnit);

        return Ok(newWeightUnit);
    }
}