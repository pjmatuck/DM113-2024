using Grpc.Core;
using HelloPackage;

namespace server;

class Program
{
    const int Port = 50001;
    static void Main(string[] args)
    {
        Server server = null;

        try
        {
            server = new Server {
                Services = {HelloService.BindService(new HelloServiceImpl())},
                Ports = {new ServerPort("localhost", Port, ServerCredentials.Insecure)}
            };
            server.Start();
            Console.WriteLine($"Server up. Listening port: {Port}");
            Console.ReadKey();
        }
        catch (IOException e)
        {
            Console.WriteLine(
                $"Failed to connect on Grpc server. Error {e.Message}");
        }
        finally
        {
            if(server != null)
                server.ShutdownAsync().Wait();
        }
    }
}
