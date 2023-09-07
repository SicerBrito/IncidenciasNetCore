using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class DetalleIncidenciaController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public DetalleIncidenciaController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleIncidencia>>> Get()
    {
        var detalleIncidencias = await _unitOfWork.DetalleIncidencias!.GetAllAsync();
        return Ok(detalleIncidencias);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var detalleIncidencias = await _unitOfWork.DetalleIncidencias!.GetByIdAsync(id)!;
        return Ok(detalleIncidencias);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(DetalleIncidencia detalleIncidencia){
        this._unitOfWork.DetalleIncidencias!.Add(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        if (detalleIncidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = detalleIncidencia.Pk_DetalleIncidencia}, detalleIncidencia); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleIncidencia>> Put(int id, [FromBody]DetalleIncidencia detalleIncidencia){
        if(detalleIncidencia == null)
            return NotFound();
        _unitOfWork.DetalleIncidencias!.Update(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        return detalleIncidencia;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var detalleIncidencia = await _unitOfWork.DetalleIncidencias!.GetByIdAsync(id)!;
        if(detalleIncidencia == null){
            return NotFound();
        }
        _unitOfWork.DetalleIncidencias.Remove(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        return NoContent(); 
    }
}