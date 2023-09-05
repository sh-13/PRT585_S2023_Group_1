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
    public class CityController : BaseController
    {

        private readonly ICityService _CityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService CityService, ILogger<CityController> logger)
        {
            _CityService = CityService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllCities")]
        public async Task<List<CityDto>> GetAll()
        {
            var result = await _CityService.GetAll();
            return result.Select(x => x.ToCityDto()).ToList();
        }

        [HttpGet("{CityId}", Name = "GetCity")]
        public async Task<CityDto?> Get(int CityId)
        {
            var result = await _CityService.GetById(CityId);
            return result?.ToCityDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] CityDto requestDto)
        {
            var CityModel = requestDto.ToCityModel();
            return await _CityService.CreateCity(CityModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] CityDto requestDto)
        {
            await _CityService.UpdateCity(requestDto.ToCityModel());
            return Ok();
        }

        [HttpDelete, Route("{CityId}")]
        public async Task<IActionResult> Delete(int CityId)
        {
            await _CityService.DeleteCity(CityId);
            return Ok();
        }
    }
}
