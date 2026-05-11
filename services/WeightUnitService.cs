using Backend.models;
using FitBudBackend.data;
using Microsoft.EntityFrameworkCore;

namespace Backend.services;

public class WeightUnitService
{
    private readonly DatabaseContext _databaseContext;

    public WeightUnitService(DatabaseContext context)
    {
        _databaseContext = context;
    }

    // Fetch All Weight Units
    public async Task<IEnumerable<WeightUnit>> FetchAllWeightUnits()
    {
        return await _databaseContext.WeightUnits.ToListAsync();
    }

    // Create Weight Unit
    public async Task<WeightUnit> CreateWeightUnit(WeightUnit weightUnit)
    {
        _databaseContext.WeightUnits.Add(weightUnit);
        await _databaseContext.SaveChangesAsync();

        return weightUnit;
    }
}