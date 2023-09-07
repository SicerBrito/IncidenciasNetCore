using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class NivelIncidenciaController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public NivelIncidenciaController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NivelIncidencia>>> Get()
    {
        var nivelIncidencias = await _unitOfWork.NivelIncidencias!.GetAllAsync();
        return Ok(nivelIncidencias);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var nivelIncidencias = await _unitOfWork.NivelIncidencias!.GetByIdAsync(id)!;
        return Ok(nivelIncidencias);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NivelIncidencia>> Post(NivelIncidencia nivelIncidencia){
        this._unitOfWork.NivelIncidencias!.Add(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        if (nivelIncidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = nivelIncidencia.Pk_Id}, nivelIncidencia); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NivelIncidencia>> Put(int id, [FromBody]NivelIncidencia nivelIncidencia){
        if(nivelIncidencia == null)
            return NotFound();
        _unitOfWork.NivelIncidencias!.Update(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        return nivelIncidencia;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var nivelIncidencia = await _unitOfWork.NivelIncidencias!.GetByIdAsync(id)!;
        if(nivelIncidencia == null){
            return NotFound();
        }
        _unitOfWork.NivelIncidencias.Remove(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}