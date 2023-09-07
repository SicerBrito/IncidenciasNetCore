using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class UserController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return Ok(users);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var users = await _unitOfWork.Users.GetByIdAsync(id);
        return Ok(users);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(User user){
        this._unitOfWork.Users.Add(user);
        await _unitOfWork.SaveAsync();
        if (user == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = user.Id}, user); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Put(int id, [FromBody]User user){
        if(user == null)
            return NotFound();
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveAsync();
        return user;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if(user == null){
            return NotFound();
        }
        _unitOfWork.Users.Remove(user);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}