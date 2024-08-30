using MediaNotasSoapService.Services;
using SoapCore;

namespace MediaNotasSoapService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IMediaService, MediaService>();

            // Add services to the container.
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSoapEndpoint<IMediaService>("/MediaService.wsdl",
                new SoapEncoderOptions());

            app.MapControllers();

            app.Run();
        }
    }
}
