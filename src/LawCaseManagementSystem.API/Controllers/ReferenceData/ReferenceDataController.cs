using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Domain.Entities.Common;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[ApiController]
public abstract class ReferenceDataControllerBase<TEntity> : ControllerBase
    where TEntity : ReferenceDataEntity
{
    private readonly IReferenceDataService<TEntity> _service;

    protected ReferenceDataControllerBase(IReferenceDataService<TEntity> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReferenceDataDto>>> GetAll([FromQuery] bool includeInactive = false)
    {
        var result = await _service.GetAllAsync(includeInactive);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReferenceDataDto>> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        return result is null
            ? NotFound()
            : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ReferenceDataDto>> Create(CreateReferenceDataDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ReferenceDataDto>> Update(Guid id, UpdateReferenceDataDto dto)
    {
        try
        {
            var result =
                await _service.UpdateAsync(id, dto);

            return result is null
                ? NotFound()
                : Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var success =
            await _service.SetActiveAsync(id, true);

        return success
            ? NoContent()
            : NotFound();
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var success = await _service.SetActiveAsync(id, false);

        return success
            ? NoContent()
            : NotFound();
    }
}