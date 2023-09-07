using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoContactoController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public TipoContactoController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoContacto>>> Get()
    {
        var tipoContactos = await _unitOfWork.TipoContactos!.GetAllAsync();
        return Ok(tipoContactos);
    } 
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GeId(string id)
    {
        var tipoContactos = await _unitOfWork.TipoContactos!.GetByIdAsync(id)!;
        return Ok(tipoContactos); 
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoContacto>> Post(TipoContacto tipoContacto){
        this._unitOfWork.TipoContactos!.Add(tipoContacto);
        await _unitOfWork.SaveAsync();
        if (tipoContacto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = tipoContacto.Pk_Id}, tipoContacto); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoContacto>> Put(int id, [FromBody]TipoContacto tipoContacto){
        if(tipoContacto == null)
            return NotFound();
        _unitOfWork.TipoContactos!.Update(tipoContacto);
        await _unitOfWork.SaveAsync();
        return tipoContacto;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var tipoContacto = await _unitOfWork.TipoContactos!.GetByIdAsync(id)!;
        if(tipoContacto == null){
            return NotFound();
        }
        _unitOfWork.TipoContactos.Remove(tipoContacto);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}