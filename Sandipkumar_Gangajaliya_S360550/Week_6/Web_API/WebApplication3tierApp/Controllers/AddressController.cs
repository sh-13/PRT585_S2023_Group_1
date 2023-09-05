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
    public class AddressController : BaseController
    {

        private readonly IAddressService _AddressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressService AddressService, ILogger<AddressController> logger)
        {
            _AddressService = AddressService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllAddresses")]
        public async Task<List<AddressDto>> GetAll()
        {
            var result = await _AddressService.GetAll();
            return result.Select(x => x.ToAddressDto()).ToList();
        }

        [HttpGet("{AddressId}", Name = "GetAddress")]
        public async Task<AddressDto?> Get(int AddressId)
        {
            var result = await _AddressService.GetById(AddressId);
            return result?.ToAddressDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] AddressDto requestDto)
        {
            var AddressModel = requestDto.ToAddressModel();
            return await _AddressService.CreateAddress(AddressModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] AddressDto requestDto)
        {
            await _AddressService.UpdateAddress(requestDto.ToAddressModel());
            return Ok();
        }

        [HttpDelete, Route("{AddressId}")]
        public async Task<IActionResult> Delete(int AddressId)
        {
            await _AddressService.DeleteAddress(AddressId);
            return Ok();
        }
    }
}
