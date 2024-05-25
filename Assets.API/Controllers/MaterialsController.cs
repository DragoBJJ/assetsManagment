using Assets.Application.Materials.Commands.CreateMaterial;
using Assets.Application.Materials.DTO;
using Assets.Application.Materials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Assets.API.Controllers;


[Route("api/assets/{assetId}/materials")]
[ApiController]
public class MaterialsController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateMaterial([FromRoute] int assetId, CreateMaterialCommand command)
    {
        command.AssetId = assetId;
        await mediator.Send(command);
        return Created();
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllFromAsset([FromRoute] int assetId)
    {
        var materials = await mediator.Send(new GetMaterialsForAssetQuery(assetId));
        return Ok(materials);

    }

    [HttpGet("{materialId}")]
    public async Task<ActionResult<MaterialDTO>> GetByIdFromAsset([FromRoute] int assetId, [FromRoute] int materialId)
    {
        {
            var materialDto = await mediator.Send(new GetMaterialByIdForAssetQuery(assetId, materialId));

            return Ok(materialDto);
        }
    }

}