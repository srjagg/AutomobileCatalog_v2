using AutomobileCatalog.Core.CoreImplement;
using AutomobileCatalog.Core.CoreInterface;
using AutomobileCatalog.Models.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsControllers : ControllerBase
    {
        private readonly IBrandsCore _brandsCore;

        public BrandsControllers(IBrandsCore brandsCore)
        {
            _brandsCore = brandsCore;
        }

        [HttpPost]
        public async Task<IActionResult> InsertBrandAsync(BrandsDto brandsDto)
        {
            if (brandsDto == null)
                return BadRequest();

            var response = await _brandsCore.AddBrandAsync(brandsDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
