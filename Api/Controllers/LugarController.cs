using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class LugarController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public LugarController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Lugar>>> Get()
    {
        var lugares = await _unitOfWork.Lugares!.GetAllAsync();
        return Ok(lugares);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var lugares = await _unitOfWork.Lugares!.GetByIdAsync(id)!;
        return Ok(lugares);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Lugar lugar){
        this._unitOfWork.Lugares!.Add(lugar);
        await _unitOfWork.SaveAsync();
        if (lugar == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = lugar.Pk_Id}, lugar); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Lugar>> Put(int id, [FromBody]Lugar lugar){
        if(lugar == null)
            return NotFound();
        _unitOfWork.Lugares!.Update(lugar);
        await _unitOfWork.SaveAsync();
        return lugar;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var lugar = await _unitOfWork.Lugares!.GetByIdAsync(id)!;
        if(lugar == null){
            return NotFound();
        }
        _unitOfWork.Lugares.Remove(lugar);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}