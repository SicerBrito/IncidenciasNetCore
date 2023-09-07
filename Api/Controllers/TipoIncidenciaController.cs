using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoIncidenciaController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public TipoIncidenciaController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoIncidencia>>> Get()
    {
        var tipoIncidencias = await _unitOfWork.TipoIncidencias!.GetAllAsync();
        return Ok(tipoIncidencias);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var tipoIncidencias = await _unitOfWork.TipoIncidencias!.GetByIdAsync(id)!;
        return Ok(tipoIncidencias);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(TipoIncidencia tipoIncidencia){
        this._unitOfWork.TipoIncidencias!.Add(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        if (tipoIncidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = tipoIncidencia.Pk_Id}, tipoIncidencia); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidencia>> Put(int id, [FromBody]TipoIncidencia tipoIncidencia){
        if(tipoIncidencia == null)
            return NotFound();
        _unitOfWork.TipoIncidencias!.Update(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        return tipoIncidencia;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var tipoIncidencia = await _unitOfWork.TipoIncidencias!.GetByIdAsync(id)!;
        if(tipoIncidencia == null){
            return NotFound();
        }
        _unitOfWork.TipoIncidencias.Remove(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}