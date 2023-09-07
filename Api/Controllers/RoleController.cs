using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class RoleController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Role>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return Ok(roles);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var roles = await _unitOfWork.Roles.GetByIdAsync(id);
        return Ok(roles);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Post(Role role){
        this._unitOfWork.Roles.Add(role);
        await _unitOfWork.SaveAsync();
        if (role == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = role.Id}, role); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Put(int id, [FromBody]Role role){
        if(role == null)
            return NotFound();
        _unitOfWork.Roles.Update(role);
        await _unitOfWork.SaveAsync();
        return role;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if(role == null){
            return NotFound();
        }
        _unitOfWork.Roles.Remove(role);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}