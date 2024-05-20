using Assets.Application.Assets.Commands.CreateAsset;
using Assets.Application.Assets.Commands.DeleteAsset;
using Assets.Application.Assets.Commands.UpdateAsset;
using Assets.Application.Assets.Queries.GetAllAssets;
using Assets.Application.Assets.Queries.GetAssetById;
using Assets.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Assets.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await mediator.Send(new GetAllAssetsQuery());       
            return Ok(assets);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var asset = await mediator.Send(new GetAssetByIdQuery(id));

            if(asset is null)
            {
                return NotFound($"Asset by ID: {id} Not found");
            }

           
            return Ok(asset);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteAssetCommand(id));

            if (isDeleted is false)
            {
                return NotFound($"Asset by ID: {id} Not found");
            }


            return NoContent();
        }

        [HttpPost]
            public async Task<IActionResult> CreateAsset(CreateAssetCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetByID), new { id}, null);    
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsset([FromRoute] int id, UpdateAssetCommand command)
        {  
                command.Id = id;
                var assetDto = await mediator.Send(command);

                if (assetDto is null)
                    {
                    return NotFound($"Asset by ID: {id} Not found");
            }

            return  Ok(assetDto);
        }

    }
}
