using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoDocumentoController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public TipoDocumentoController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
    {
        var tipoDocumentos = await _unitOfWork.TipoDocumentos.GetAllAsync();
        return Ok(tipoDocumentos);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var tipoDocumentos = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        return Ok(tipoDocumentos);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Post(TipoDocumento tipoDocumento){
        this._unitOfWork.TipoDocumentos.Add(tipoDocumento);
        await _unitOfWork.SaveAsync();
        if (tipoDocumento == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = tipoDocumento.Id}, tipoDocumento); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Put(int id, [FromBody]TipoDocumento tipoDocumento){
        if(tipoDocumento == null)
            return NotFound();
        _unitOfWork.TipoDocumentos.Update(tipoDocumento);
        await _unitOfWork.SaveAsync();
        return tipoDocumento;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if(tipoDocumento == null){
            return NotFound();
        }
        _unitOfWork.TipoDocumentos.Remove(tipoDocumento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}