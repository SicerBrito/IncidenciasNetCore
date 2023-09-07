using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class DocTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public DocTypeController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocType>>> Get()
    {
        var docTypes = await _unitOfWork.DocTypes.GetAllAsync();
        return Ok(docTypes);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var docTypes = await _unitOfWork.DocTypes.GetByIdAsync(id);
        return Ok(docTypes);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocType>> Post(DocType docType){
        this._unitOfWork.DocTypes.Add(docType);
        await _unitOfWork.SaveAsync();
        if (docType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = docType.Id}, docType); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocType>> Put(int id, [FromBody]DocType docType){
        if(docType == null)
            return NotFound();
        _unitOfWork.DocTypes.Update(docType);
        await _unitOfWork.SaveAsync();
        return docType;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var docType = await _unitOfWork.DocTypes.GetByIdAsync(id);
        if(docType == null){
            return NotFound();
        }
        _unitOfWork.DocTypes.Remove(docType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}