using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class UsuarioController : ApiBaseController
{
    private readonly IUnitOfWork _UnitOfWork;

    public UsuarioController(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()
    {
        var usuarios = await _UnitOfWork.Usuarios!.GetAllAsync();
        return Ok(usuarios);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var usuarios = await _UnitOfWork.Usuarios!.GetByIdAsync(id)!;
        return Ok(usuarios);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Usuario usuario){
        this._UnitOfWork.Usuarios!.Add(usuario);
        await _UnitOfWork.SaveAsync();
        if (usuario == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = usuario.Pk_IdUser}, usuario); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Usuario>> Put(int id, [FromBody]Usuario usuario){
        if(usuario == null)
            return NotFound();
        _UnitOfWork.Usuarios!.Update(usuario);
        await _UnitOfWork.SaveAsync();
        return usuario;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var usuario = await _UnitOfWork.Usuarios!.GetByIdAsync(id)!;
        if(usuario == null){
            return NotFound();
        }
        _UnitOfWork.Usuarios.Remove(usuario);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}