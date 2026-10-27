using Training.Application.ValidationService;

namespace Training.API.Csproj;

public class ValidateEndpoint
{
    private readonly ITransferValidationService _validateService;

    public ValidateEndpoint(ITransferValidationService validateService)
    {
        _validateService = validateService;
    }
}