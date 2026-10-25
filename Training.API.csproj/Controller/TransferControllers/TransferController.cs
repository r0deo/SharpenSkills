using Microsoft.AspNetCore.Mvc;
using Training.Application.ValidationService;

[ApiController]
[Route("transfers")]
public class TransfersController : ControllerBase
{
    private readonly ITransferValidationService _service;

    public TransfersController(
        ITransferValidationService service)
    {
         _service = service;
    }
    [HttpPost("validate")]
    public IActionResult Validate(
        [FromBody] TransferValidationRequest request)
    {
        var result = _service.Validate(request);
        if (result.IsValid)
        {
             return Ok(result);
        }
        return BadRequest(result);
    }
}