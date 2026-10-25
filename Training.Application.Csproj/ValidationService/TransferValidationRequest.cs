namespace Training.Application.ValidationService;

public class TransferValidationRequest
{
    public decimal Amount { get; set; }
    public string? FromAccountId { get; set; }
    public string? ToAccountId { get; set; }
}
