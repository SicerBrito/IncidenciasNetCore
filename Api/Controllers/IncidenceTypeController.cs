using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class IncidenceTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceTypeController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceType>>> Get()
    {
        var incidenceTypes = await _unitOfWork.IncidenceTypes.GetAllAsync();
        return Ok(incidenceTypes);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var incidenceTypes = await _unitOfWork.IncidenceTypes.GetByIdAsync(id);
        return Ok(incidenceTypes);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(IncidenceType incidenceType){
        this._unitOfWork.IncidenceTypes.Add(incidenceType);
        await _unitOfWork.SaveAsync();
        if (incidenceType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = incidenceType.Id}, incidenceType); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceType>> Put(int id, [FromBody]IncidenceType incidenceType){
        if(incidenceType == null)
            return NotFound();
        _unitOfWork.IncidenceTypes.Update(incidenceType);
        await _unitOfWork.SaveAsync();
        return incidenceType;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidenceType = await _unitOfWork.IncidenceTypes.GetByIdAsync(id);
        if(incidenceType == null){
            return NotFound();
        }
        _unitOfWork.IncidenceTypes.Remove(incidenceType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}