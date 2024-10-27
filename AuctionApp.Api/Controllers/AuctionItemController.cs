using AuctionApp.DataLayer.Dtos;
using AuctionApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionItemController : ControllerBase
    {
        private readonly IAuctionItemService _service;

        public AuctionItemController(IAuctionItemService service)
        {
            _service = service;

        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AuctionItemDto>>> Get()
        {
            var result = await _service.GetAllServiceAsync();
            if(result?.Count() > 0)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AuctionItemDto>> Get([FromRoute] int id)
        {
            var result = await _service.GetByIdServiceAsync(id);
            if(result != null)
                return Ok(result);
            else 
                return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AuctionItemDto>> Post(AuctionItemDto createDto)
        {
            var result = await _service.CreateServiceAsync(createDto);
            if (result != null)
                return Ok("Created Successfully");
            else 
                return BadRequest("Failed to Create");
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<AuctionItemDto>> Put(AuctionItemDto editDto)
        {
            var result = await _service.UpdateServiceAsync(editDto);
            if (result != null)
                return Ok("Updated Successfully");
            else
                return BadRequest("Failed to Update");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteServiceAsync(id);
            if (result != null)
                return NoContent();
            else
                return NotFound();
        }
    }
}
