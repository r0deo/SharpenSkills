namespace Training.Application.ValidationService;

public class TransferValidationService : ITransferValidationService
{
    public TransferValidationResult Validate(
        TransferValidationRequest request)
    {
        var errors = new List<string>();

        // Rule 1: Amount must be positive
        if (request.Amount <= 0)
        {
            errors.Add("Amount must be greater than zero.");
        }

        // Rule 2: Source account is required
        if (string.IsNullOrWhiteSpace(request.FromAccountId))
        {
            errors.Add("Source account is required.");
        }

        // Rule 3: Destination account is required
        if (string.IsNullOrWhiteSpace(request.ToAccountId))
        {
            errors.Add("Destination account is required.");
        }

        // Rule 4: Accounts must be different
        if (!string.IsNullOrWhiteSpace(request.FromAccountId) &&
            !string.IsNullOrWhiteSpace(request.ToAccountId) &&
            request.FromAccountId == request.ToAccountId)
        {
            errors.Add("Source and destination accounts must be different.");
        }

        return new TransferValidationResult
        {
            IsValid = errors.Count == 0,
            Errors = errors
        };
    }
}
