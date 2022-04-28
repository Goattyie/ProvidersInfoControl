using Microsoft.AspNetCore.Mvc;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Api.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult GetResponse(IOperationResult result) =>
        result.CodeResult switch
        {
            CodeResult.Ok => Ok(result),
            CodeResult.Bad => BadRequest(result),
            CodeResult.NoContext => NoContent(),
        };
}