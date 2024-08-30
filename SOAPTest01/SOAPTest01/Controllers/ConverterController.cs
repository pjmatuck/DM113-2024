using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberConversion;
using TempConvert;

namespace SOAPTest01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(long number)
        {
            NumberConversionSoapTypeClient client =
                new NumberConversionSoapTypeClient(
                    NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap12);

            client.Open();
            var result = await client.NumberToWordsAsync((ulong)number);
            client.Close();

            return Ok(result.Body.NumberToWordsResult);
        }
    }
}
