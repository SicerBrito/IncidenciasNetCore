using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class StateController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public StateController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<State>>> Get()
    {
        var states = await _unitOfWork.States.GetAllAsync();
        return Ok(states);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var states = await _unitOfWork.States.GetByIdAsync(id);
        return Ok(states);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(State state){
        this._unitOfWork.States.Add(state);
        await _unitOfWork.SaveAsync();
        if (state == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = state.Id}, state); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Put(int id, [FromBody]State state){
        if(state == null)
            return NotFound();
        _unitOfWork.States.Update(state);
        await _unitOfWork.SaveAsync();
        return state;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var state = await _unitOfWork.States.GetByIdAsync(id);
        if(state == null){
            return NotFound();
        }
        _unitOfWork.States.Remove(state);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}