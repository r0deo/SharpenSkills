namespace Training.Application.ValidationService;

public interface ITransferValidationService
{
    TransferValidationResult Validate(
        TransferValidationRequest request);
}
