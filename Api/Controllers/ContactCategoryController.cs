using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class ContactCategoryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactCategoryController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactCategory>>> Get()
    {
        var contactCategories = await _unitOfWork.ContactCategories.GetAllAsync();
        return Ok(contactCategories);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var contactCategories = await _unitOfWork.ContactCategories.GetByIdAsync(id);
        return Ok(contactCategories);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactCategory>> Post(ContactCategory contactCategory){
        this._unitOfWork.ContactCategories.Add(contactCategory);
        await _unitOfWork.SaveAsync();
        if (contactCategory == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = contactCategory.Id}, contactCategory); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactCategory>> Put(int id, [FromBody]ContactCategory contactCategory){
        if(contactCategory == null)
            return NotFound();
        _unitOfWork.ContactCategories.Update(contactCategory);
        await _unitOfWork.SaveAsync();
        return contactCategory;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contactCategory = await _unitOfWork.ContactCategories.GetByIdAsync(id);
        if(contactCategory == null){
            return NotFound();
        }
        _unitOfWork.ContactCategories.Remove(contactCategory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}