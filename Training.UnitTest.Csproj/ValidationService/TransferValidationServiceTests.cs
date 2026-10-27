using Training.Application.ValidationService;
using Xunit;
namespace Training.UnitTest.ValidationService;


public class TransferValidationServiceTests
{
    [Fact]
    public void Validate_NegativeAmount_ReturnsError()
    {
        // Arrange
        // Create the service
        var service = new TransferValidationService();
        // Create request with Amount = -100
        var request = new TransferValidationRequest
        {
            FromAccountId = "A200",
            ToAccountId = "B300",
            Amount = -100
        };

        // Act
        // Call Validate(request)
        var result = service.Validate(request);

        // Assert
        // Verify IsValid is false
        Assert.False(result.IsValid);
        Assert.Contains("Amount must be greater than zero.", result.Errors);
    }

    [Fact]
    public void Validate_SameAccountIds_ReturnsError()
    {
        var service = new TransferValidationService();
        var request = new TransferValidationRequest
        {
            FromAccountId = "A100",
            ToAccountId = "A100",
            Amount = 300
        };
        var result = service.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains("Source and destination accounts must be different.", result.Errors);

    }

      [Fact]
    public void Validate_FromAccountIsEmpty_ReturnsError()
    {
        var service = new TransferValidationService();
        var request = new TransferValidationRequest
        {
            FromAccountId = " ",
            ToAccountId = "A100",
            Amount = 300
        };
        var result = service.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains("Source must not empty.", result.Errors);

    }
}
