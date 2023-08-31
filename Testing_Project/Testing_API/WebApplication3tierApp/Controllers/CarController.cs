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
    public class CarController : BaseController
    {

        private readonly ICarService _CarService;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarService CarService, ILogger<CarController> logger)
        {
            _CarService = CarService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllCars")]
        public async Task<List<CarDto>> GetAll()
        {
            var result = await _CarService.GetAll();
            return result.Select(x => x.ToCarDto()).ToList();
        }

        [HttpGet("{CarId}", Name = "GetCar")]
        public async Task<CarDto?> Get(int CarId)
        {
            var result = await _CarService.GetById(CarId);
            return result?.ToCarDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] CarDto requestDto)
        {
            var CarModel = requestDto.ToCarModel();
            return await _CarService.CreateCar(CarModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] CarDto requestDto)
        {
            await _CarService.UpdateCar(requestDto.ToCarModel());
            return Ok();
        }

        [HttpDelete, Route("{CarId}")]
        public async Task<IActionResult> Delete(int CarId)
        {
            await _CarService.DeleteCar(CarId);
            return Ok();
        }
    }
}
