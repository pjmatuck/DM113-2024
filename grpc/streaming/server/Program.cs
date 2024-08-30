using Grpc.Core;
using Messageapp;
using server.service;

namespace server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server()
                {
                    Services = { MessageService.BindService(new MessageServiceImpl()) },
                    Ports = { new ServerPort("localhost", 50005, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine("Server running on port 50005");
                Console.ReadKey();
            } 
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }
        }
    }
}
