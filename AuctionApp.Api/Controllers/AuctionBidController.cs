using AuctionApp.DataLayer.Dtos;
using AuctionApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionBidController : ControllerBase
    {
        private readonly IAuctionBidService _service;

        public AuctionBidController(IAuctionBidService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AuctionBidDto>> Post(AuctionBidDto createDto)
        {
            var result = await _service.CreateServiceAsync(createDto);
            if (result != null)
                return Ok("Created Successfully");
            else
                return BadRequest("Failed to Create");
        }
    }
}
