using _2DataAccessLayer.Services;
using _3BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3tierApp.Models;

namespace WebApplication3tierApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BikeController : BaseController
    {

        private readonly IBikeService _BikeService;
        private readonly ILogger<BikeController> _logger;

        public BikeController(IBikeService BikeService, ILogger<BikeController> logger)
        {
            _BikeService = BikeService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllBikes")]
        public async Task<List<BikeDto>> GetAll()
        {
            var result = await _BikeService.GetAll();
            return result.Select(x => x.ToBikeDto()).ToList();
        }

        [HttpGet("{BikeId}", Name = "GetBike")]
        public async Task<BikeDto?> Get(int BikeId)
        {
            var result = await _BikeService.GetById(BikeId);
            return result?.ToBikeDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] BikeDto requestDto)
        {
            var BikeModel = requestDto.ToBikeModel();
            return await _BikeService.CreateBike(BikeModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] BikeDto requestDto)
        {
            await _BikeService.UpdateBike(requestDto.ToBikeModel());
            return Ok();
        }

        [HttpDelete, Route("{BikeId}")]
        public async Task<IActionResult> Delete(int BikeId)
        {
            await _BikeService.DeleteBike(BikeId);
            return Ok();
        }
    }
}
