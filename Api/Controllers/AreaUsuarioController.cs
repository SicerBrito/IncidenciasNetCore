using Aplicacion.UnitOfWork;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class AreaUsuarioController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public AreaUsuarioController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AreaUsuario>>> Get()
    {
        var areaUsuarios = await _unitOfWork.AreaUsuarios!.GetAllAsync();
        return Ok(areaUsuarios);
    }
    [HttpGet("{GetId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var areaUsuarios = await _unitOfWork.AreaUsuarios!.GetByIdAsync(id)!;
        return Ok(areaUsuarios);
    }
    // [POST]
    [HttpPost("{PostId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaUsuario>> Post(AreaUsuario areaUsuario){
        this._unitOfWork.AreaUsuarios!.Add(areaUsuario);
        await _unitOfWork.SaveAsync();
        if (areaUsuario == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = areaUsuario.Pk_AreaUsuario}, areaUsuario); 
    }
    // [PUT]
    [HttpPut("{PutId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaUsuario>> Put(int id, [FromBody]AreaUsuario areaUsuario){
        if(areaUsuario == null)
            return NotFound();
        _unitOfWork.AreaUsuarios!.Update(areaUsuario);
        await _unitOfWork.SaveAsync();
        return areaUsuario;
    }
    // [DELETE]
    [HttpDelete("{DeleteId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var areaUsuario = await _unitOfWork.AreaUsuarios!.GetByIdAsync(id)!;
        if(areaUsuario == null){
            return NotFound();
        }
        _unitOfWork.AreaUsuarios.Remove(areaUsuario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}