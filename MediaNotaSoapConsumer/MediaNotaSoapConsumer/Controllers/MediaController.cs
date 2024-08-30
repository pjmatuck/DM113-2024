using MediaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaNotaSoapConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        /*[HttpGet]
        public async Task<IActionResult> CalcularMedia(float nota1, float nota2)
        {
            MediaServiceClient soapClient = new MediaServiceClient(
                MediaServiceClient
                .EndpointConfiguration
                .BasicHttpBinding_IMediaService);

            await soapClient.OpenAsync();
            var result = await soapClient.CalcularMediaAsync(nota1, nota2);
            await soapClient.CloseAsync();

            return Ok(result);
        }*/

        [HttpGet]
        public async Task<IActionResult> GetProva(string disciplina)
        {
            MediaServiceClient soapClient = new MediaServiceClient(
                MediaServiceClient
                .EndpointConfiguration
                .BasicHttpBinding_IMediaService);

            await soapClient.OpenAsync();
            var result = soapClient.GetProvaAsync(disciplina);
            await soapClient.CloseAsync();

            return Ok(result);
        }
    }
}
