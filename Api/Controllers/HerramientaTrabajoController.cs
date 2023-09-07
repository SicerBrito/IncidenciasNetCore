using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HerramientaTrabajoController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public HerramientaTrabajoController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<HerramientaTrabajo>>> Get()
    {
        var herramientaTrabajos = await _unitOfWork.HerramientaTrabajos.GetAllAsync();
        return Ok(herramientaTrabajos);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var herramientaTrabajos = await _unitOfWork.HerramientaTrabajos.GetByIdAsync(id);
        return Ok(herramientaTrabajos);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HerramientaTrabajo>> Post(HerramientaTrabajo herramientaTrabajo){
        this._unitOfWork.HerramientaTrabajos.Add(herramientaTrabajo);
        await _unitOfWork.SaveAsync();
        if (herramientaTrabajo == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = herramientaTrabajo.Id}, herramientaTrabajo); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HerramientaTrabajo>> Put(int id, [FromBody]HerramientaTrabajo herramientaTrabajo){
        if(herramientaTrabajo == null)
            return NotFound();
        _unitOfWork.HerramientaTrabajos.Update(herramientaTrabajo);
        await _unitOfWork.SaveAsync();
        return herramientaTrabajo;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var herramientaTrabajo = await _unitOfWork.HerramientaTrabajos.GetByIdAsync(id);
        if(herramientaTrabajo == null){
            return NotFound();
        }
        _unitOfWork.HerramientaTrabajos.Remove(herramientaTrabajo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}