using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberConversion;

namespace NumbersToWordsSOAPConsumer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> NumberToWord(long number)
        {
            NumberConversionSoapTypeClient soapClient =
                new NumberConversionSoapTypeClient(
                    NumberConversionSoapTypeClient
                    .EndpointConfiguration
                    .NumberConversionSoap12);

            soapClient.Open();
            var result = await soapClient.NumberToWordsAsync((ulong)number);
            soapClient.Close();

            return Ok(result.Body.NumberToWordsResult);
        }
    }
}
