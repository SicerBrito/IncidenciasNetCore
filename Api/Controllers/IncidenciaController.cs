using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class IncidenciaController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenciaController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Incidencia>>> Get()
    {
        var incidencias = await _unitOfWork.Incidencias.GetAllAsync();
        return Ok(incidencias);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var incidencias = await _unitOfWork.Incidencias.GetByIdAsync(id);
        return Ok(incidencias);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidencia>> Post(Incidencia incidencia){
        this._unitOfWork.Incidencias.Add(incidencia);
        await _unitOfWork.SaveAsync();
        if (incidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = incidencia.Id}, incidencia); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidencia>> Put(int id, [FromBody]Incidencia incidencia){
        if(incidencia == null)
            return NotFound();
        _unitOfWork.Incidencias.Update(incidencia);
        await _unitOfWork.SaveAsync();
        return incidencia;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidencia = await _unitOfWork.Incidencias.GetByIdAsync(id);
        if(incidencia == null){
            return NotFound();
        }
        _unitOfWork.Incidencias.Remove(incidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}