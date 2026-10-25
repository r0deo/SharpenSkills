using Training.Application.ValidationService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<
    ITransferValidationService,
    TransferValidationService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
