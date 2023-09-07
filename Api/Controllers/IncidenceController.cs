using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class IncidenceController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Incidence>>> Get()
    {
        var incidences = await _unitOfWork.Incidences.GetAllAsync();
        return Ok(incidences);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var incidences = await _unitOfWork.Incidences.GetByIdAsync(id);
        return Ok(incidences);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Post(Incidence incidence){
        this._unitOfWork.Incidences.Add(incidence);
        await _unitOfWork.SaveAsync();
        if (incidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = incidence.Id}, incidence); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Put(int id, [FromBody]Incidence incidence){
        if(incidence == null)
            return NotFound();
        _unitOfWork.Incidences.Update(incidence);
        await _unitOfWork.SaveAsync();
        return incidence;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidence = await _unitOfWork.Incidences.GetByIdAsync(id);
        if(incidence == null){
            return NotFound();
        }
        _unitOfWork.Incidences.Remove(incidence);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}