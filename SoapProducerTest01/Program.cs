using SoapCore;
using SoapCar;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IAccelerationService, AccelerationService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSoapEndpoint<IAccelerationService>(
    "/Service.asmx", new SoapEncoderOptions());
app.UseAuthorization();
app.MapControllers();

//app.MapGet("/", () => "Este é um serviço SOAP!");

app.Run();
