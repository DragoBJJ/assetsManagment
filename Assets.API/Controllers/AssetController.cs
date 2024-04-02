using Microsoft.AspNetCore.Mvc;
using Assets.Application.Assets;

namespace Assets.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController(IAssetsService assetsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await assetsService.GetAllAssets();
            return Ok(assets);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var asset = await assetsService.GetAssetByID(id);

            if(asset == null)
            {
                return NotFound($"Asset by ID: {id} Not found");
            }

            return Ok(asset);
        }

    }
}
