using Application.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class AreaUserController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public AreaUserController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AreaUser>>> Get()
    {
        var areaUsers = await _unitOfWork.AreaUsers.GetAllAsync();
        return Ok(areaUsers);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var areaUsers = await _unitOfWork.AreaUsers.GetByIdAsync(id);
        return Ok(areaUsers);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaUser>> Post(AreaUser areaUser){
        this._unitOfWork.AreaUsers.Add(areaUser);
        await _unitOfWork.SaveAsync();
        if (areaUser == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = areaUser.Id}, areaUser); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaUser>> Put(int id, [FromBody]AreaUser areaUser){
        if(areaUser == null)
            return NotFound();
        _unitOfWork.AreaUsers.Update(areaUser);
        await _unitOfWork.SaveAsync();
        return areaUser;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var areaUser = await _unitOfWork.AreaUsers.GetByIdAsync(id);
        if(areaUser == null){
            return NotFound();
        }
        _unitOfWork.AreaUsers.Remove(areaUser);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}