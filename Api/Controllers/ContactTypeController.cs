using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class ContactTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactTypeController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactType>>> Get()
    {
        var contactTypes = await _unitOfWork.ContactTypes.GetAllAsync();
        return Ok(contactTypes);
    } 
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GeId(int id)
    {
        var contactTypes = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        return Ok(contactTypes);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Post(ContactType contactType){
        this._unitOfWork.ContactTypes.Add(contactType);
        await _unitOfWork.SaveAsync();
        if (contactType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = contactType.Id}, contactType); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Put(int id, [FromBody]ContactType contactType){
        if(contactType == null)
            return NotFound();
        _unitOfWork.ContactTypes.Update(contactType);
        await _unitOfWork.SaveAsync();
        return contactType;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if(contactType == null){
            return NotFound();
        }
        _unitOfWork.ContactTypes.Remove(contactType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}