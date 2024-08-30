using System.Threading.Channels;
using Grpc.Net.Client;
using HelloPackage;

namespace client;

class Program
{
    const string server = "http://localhost:50001";
    static async Task Main(string[] args)
    {
        var channel = GrpcChannel.ForAddress(server);
        var client = new HelloService.HelloServiceClient(channel);

        Console.WriteLine("Client connected on Grpc server.");

        var request = new Request() {
            Request_ = new HelloMessage(){
                Name = "Pedro",
                Content = "Olá do cliente GRPC"
            } 
        };

        var response = await client.SayHelloAsync(request);
        Console.WriteLine(response.Response_);
        Console.ReadKey();
    }
}
