using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class RolController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public RolController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Rol>>> Get()
    {
        var roles = await _unitOfWork.Roles!.GetAllAsync();
        return Ok(roles);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var roles = await _unitOfWork.Roles!.GetByIdAsync(id)!;
        return Ok(roles);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(Rol rol){
        this._unitOfWork.Roles!.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = rol.Pk_Id}, rol); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Put(int id, [FromBody]Rol rol){
        if(rol == null)
            return NotFound();
        _unitOfWork.Roles!.Update(rol);
        await _unitOfWork.SaveAsync();
        return rol;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var rol = await _unitOfWork.Roles!.GetByIdAsync(id)!;
        if(rol == null){
            return NotFound();
        }
        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}