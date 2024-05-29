using Assets.Application.Assets.Commands.CreateAsset;
using Assets.Application.Assets.Commands.DeleteAsset;
using Assets.Application.Assets.Commands.UpdateAsset;
using Assets.Application.Assets.DTO;
using Assets.Application.Assets.Queries.GetAllAssets;
using Assets.Application.Assets.Queries.GetAssetById;
using Assets.Application.Materials.Queries.GetByCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Assets.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    [Authorize]
    public class AssetsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDTO>>> GetAll()
        {
            var assets = await mediator.Send(new GetAllAssetsQuery());
            return Ok(assets);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO?>> GetByID([FromRoute] int id)
        {
            var asset = await mediator.Send(new GetAssetByIdQuery(id));
            return Ok(asset);

        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<AssetDTO>>> GetHouseAssets([FromRoute] string category)

        {
           
           var assets = await mediator.Send(new GetByCategoryQuery(category));
            return Ok(assets);       
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsset([FromRoute] int id)
        {
            await mediator.Send(new DeleteAssetCommand(id));
            return NoContent();
        }

        [HttpPost]
            public async Task<IActionResult> CreateAsset(CreateAssetCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetByID), new { id}, null);    
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsset([FromRoute] int id, UpdateAssetCommand command)
        {  
                command.Id = id;
                var assetDto = await mediator.Send(command);
                 return  Ok(assetDto);
        }

    }
}
