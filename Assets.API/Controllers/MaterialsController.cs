using Assets.Application.Materials.Commands.CreateMaterial;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Assets.API.Controllers;


[Route("api/assets/{assetId}/dishes")]
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
    }

