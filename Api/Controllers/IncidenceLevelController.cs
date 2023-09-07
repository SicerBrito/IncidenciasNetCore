using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class IncidenceLevelController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceLevelController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceLevel>>> Get()
    {
        var incidenceLevels = await _unitOfWork.IncidenceLevels.GetAllAsync();
        return Ok(incidenceLevels);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var incidenceLevels = await _unitOfWork.IncidenceLevels.GetByIdAsync(id);
        return Ok(incidenceLevels);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceLevel>> Post(IncidenceLevel incidenceLevel){
        this._unitOfWork.IncidenceLevels.Add(incidenceLevel);
        await _unitOfWork.SaveAsync();
        if (incidenceLevel == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = incidenceLevel.Id}, incidenceLevel); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceLevel>> Put(int id, [FromBody]IncidenceLevel incidenceLevel){
        if(incidenceLevel == null)
            return NotFound();
        _unitOfWork.IncidenceLevels.Update(incidenceLevel);
        await _unitOfWork.SaveAsync();
        return incidenceLevel;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidenceLevel = await _unitOfWork.IncidenceLevels.GetByIdAsync(id);
        if(incidenceLevel == null){
            return NotFound();
        }
        _unitOfWork.IncidenceLevels.Remove(incidenceLevel);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}