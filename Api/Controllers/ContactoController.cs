using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class ContactoController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactoController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contacto>>> Get()
    {
        var contactos = await _unitOfWork.Contactos!.GetAllAsync();
        return Ok(contactos);
    }
    [HttpGet("{GetId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(string id)
    {
        var contactos = await _unitOfWork.Contactos!.GetByIdAsync(id)!;
        return Ok(contactos);
    }
    // [POST]
    [HttpPost("{PostId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contacto>> Post(Contacto contacto){
        this._unitOfWork.Contactos!.Add(contacto);
        await _unitOfWork.SaveAsync();
        if (contacto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = contacto.Pk_Numero}, contacto); 
    }
    // [PUT]
    [HttpPut("{PutId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contacto>> Put(int id, [FromBody]Contacto contacto){
        if(contacto == null)
            return NotFound();
        _unitOfWork.Contactos!.Update(contacto);
        await _unitOfWork.SaveAsync();
        return contacto;
    }
    // [DELETE]
    [HttpDelete("{DeleteId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var contact = await _unitOfWork.Contactos!.GetByIdAsync(id)!;
        if(contact == null){
            return NotFound();
        }
        _unitOfWork.Contactos.Remove(contact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}