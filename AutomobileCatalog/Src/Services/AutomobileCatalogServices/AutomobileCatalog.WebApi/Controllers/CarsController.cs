using AutomobileCatalog.Core.CoreInterface;
using AutomobileCatalog.Models.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarsCore _carsCore;

        public CarsController(ICarsCore carsCore)
        {
            _carsCore = carsCore;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCarAsync(CarsDto carDto)
        {
            if (carDto == null)
                return BadRequest();
            
            var response = await _carsCore.AddCarAsync(carDto);
            if(response.IsSuccess) 
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
