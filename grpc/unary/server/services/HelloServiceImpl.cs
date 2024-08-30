using Grpc.Core;
using HelloPackage;
public class HelloServiceImpl : HelloService.HelloServiceBase
{
    public override Task<Response> SayHello(Request request, ServerCallContext context)
    {
        System.Console.WriteLine("Request received." + request.ToString());

        HelloMessage helloMessage = new HelloMessage(){
            Name = request.Request_.Name,
            Content = request.Request_.Content
        };

        return Task.FromResult(new Response() { Response_ = HelloStatus.Failed});
    }
}