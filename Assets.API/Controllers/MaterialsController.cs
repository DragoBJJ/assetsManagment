using Assets.Application.Materials.Commands.CreateMaterial;
using Assets.Application.Materials.Commands.DeleteMaterial;
using Assets.Application.Materials.Commands.UpdateCommand;
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
        var materialId =  await mediator.Send(command);
        return CreatedAtAction(nameof(GetByIdFromAsset), new { assetId, materialId}, null);
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

    [HttpDelete]
    public async Task<IActionResult> DeleteAllFromAsset([FromRoute] int assetId)
    {
        await mediator.Send(new DeleteMaterialsCommand(assetId));
        return NoContent();
    }

    [HttpDelete("{materialId}")]
    public async Task<IActionResult> DeleteByIdFromAsset([FromRoute] int assetId, [FromRoute] int materialId)
    {
         await mediator.Send(new DeleteMaterialByIdCommand(assetId, materialId));
         return NoContent();
    }


    [HttpPatch("{materialId}")]
    public async Task<ActionResult<MaterialDTO>> UpdateByIdFromAsset([FromRoute] int assetId, [FromRoute] int materialId, [FromBody] UpdateMaterialCommand updateCommand)
    {
        updateCommand.AssetId =  assetId;
        updateCommand.MaterialId = materialId;
        var materialDto = await mediator.Send(updateCommand);

        return  Ok(materialDto);
    }

}