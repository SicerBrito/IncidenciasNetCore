using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;

public class WorkToolController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkToolController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<WorkTool>>> Get()
    {
        var workTools = await _unitOfWork.WorkTools.GetAllAsync();
        return Ok(workTools);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var workTools = await _unitOfWork.WorkTools.GetByIdAsync(id);
        return Ok(workTools);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkTool>> Post(WorkTool workTool){
        this._unitOfWork.WorkTools.Add(workTool);
        await _unitOfWork.SaveAsync();
        if (workTool == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = workTool.Id}, workTool); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkTool>> Put(int id, [FromBody]WorkTool workTool){
        if(workTool == null)
            return NotFound();
        _unitOfWork.WorkTools.Update(workTool);
        await _unitOfWork.SaveAsync();
        return workTool;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var workTool = await _unitOfWork.WorkTools.GetByIdAsync(id);
        if(workTool == null){
            return NotFound();
        }
        _unitOfWork.WorkTools.Remove(workTool);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}