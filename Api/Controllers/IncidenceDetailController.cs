using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class IncidenceDetailController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceDetailController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceDetail>>> Get()
    {
        var incidenceDetails = await _unitOfWork.IncidenceDetails.GetAllAsync();
        return Ok(incidenceDetails);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var incidenceDetails = await _unitOfWork.IncidenceDetails.GetByIdAsync(id);
        return Ok(incidenceDetails);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(IncidenceDetail incidenceDetail){
        this._unitOfWork.IncidenceDetails.Add(incidenceDetail);
        await _unitOfWork.SaveAsync();
        if (incidenceDetail == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = incidenceDetail.Id}, incidenceDetail); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceDetail>> Put(int id, [FromBody]IncidenceDetail incidenceDetail){
        if(incidenceDetail == null)
            return NotFound();
        _unitOfWork.IncidenceDetails.Update(incidenceDetail);
        await _unitOfWork.SaveAsync();
        return incidenceDetail;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidenceDetail = await _unitOfWork.IncidenceDetails.GetByIdAsync(id);
        if(incidenceDetail == null){
            return NotFound();
        }
        _unitOfWork.IncidenceDetails.Remove(incidenceDetail);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}