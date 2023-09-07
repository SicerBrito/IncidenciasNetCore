using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencePro.Controllers;
public class PlaceController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public PlaceController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    // [GET] 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Place>>> Get()
    {
        var places = await _unitOfWork.Places.GetAllAsync();
        return Ok(places);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var places = await _unitOfWork.Places.GetByIdAsync(id);
        return Ok(places);
    }
    // [POST]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Place place){
        this._unitOfWork.Places.Add(place);
        await _unitOfWork.SaveAsync();
        if (place == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = place.Id}, place); 
    }
    // [PUT]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Put(int id, [FromBody]Place place){
        if(place == null)
            return NotFound();
        _unitOfWork.Places.Update(place);
        await _unitOfWork.SaveAsync();
        return place;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var place = await _unitOfWork.Places.GetByIdAsync(id);
        if(place == null){
            return NotFound();
        }
        _unitOfWork.Places.Remove(place);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}