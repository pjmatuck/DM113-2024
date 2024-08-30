using Grpc.Net.Client;
using GrpcCalc;

namespace client
{
    internal class Program
    {
        private const string server = "http://localhost:50002";
        public static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress(server);
            var client = new CalcService.CalcServiceClient(channel);

            Console.WriteLine("Connected to GRPC server.");

            var request = new Request()
            {
                CalcRequest = new CalcMessage()
                {
                    ArgA = 50,
                    ArgB = 200
                }
            };

            var responseSum = client.Sum(request);
            Console.WriteLine($"Sum: {responseSum}");

            var responseSub = client.Sub(request);
            Console.WriteLine($"Sub: {responseSub}");

            Console.ReadKey();
        }
    }
}
