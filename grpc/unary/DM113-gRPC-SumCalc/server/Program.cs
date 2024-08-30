using Grpc.Core;
using GrpcCalc;
using server.services;

namespace server
{
    internal class Program
    {
        const int PORT = 50002;
        static void Main(string[] args)
        {
            Server server = null;
            
            try
            {
                server = new Server()
                {
                    Services = {CalcService.BindService(new CalcServiceImpl())},
                    Ports = { new ServerPort("localhost", PORT, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("Listening port: " + PORT);
                Console.ReadKey();
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            {
                if(server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
