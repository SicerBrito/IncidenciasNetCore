using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class ContactController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contact>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        return Ok(contacts);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var contacts = await _unitOfWork.Contacts.GetByIdAsync(id);
        return Ok(contacts);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Post(Contact contact){
        this._unitOfWork.Contacts.Add(contact);
        await _unitOfWork.SaveAsync();
        if (contact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = contact.Id}, contact); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Put(int id, [FromBody]Contact contact){
        if(contact == null)
            return NotFound();
        _unitOfWork.Contacts.Update(contact);
        await _unitOfWork.SaveAsync();
        return contact;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        if(contact == null){
            return NotFound();
        }
        _unitOfWork.Contacts.Remove(contact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}