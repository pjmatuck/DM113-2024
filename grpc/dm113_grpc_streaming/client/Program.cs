using Grpc.Core;
using Grpc.Net.Client;
using Messages;
using System.Threading.Channels;

namespace client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GrpcChannel channel = 
                GrpcChannel.ForAddress("http://localhost:50005");

            //await ServerStreamingCallAsync(channel);
            //await ClientStreamingCallAsync(channel);
            await BiDirectionalStreamingCallAsync(channel);
        }

        private static async Task BiDirectionalStreamingCallAsync(GrpcChannel channel)
        {
            var client = new MessageServices.MessageServicesClient(channel);
            Random random = new Random();

            int[] numbersArray =
            {
                10, 1, 11, -4, 2, 5, 12, 15, 8, 11, 18, 21, 4, 30
            };

            //Get request stream
            var request = client.GetMaxValueRealTime();

            //Listen for responses with thread
            var serverListenerTask = Task.Run(async () =>
            {
                await foreach (var response in
                    request.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine($"Server --> Client || Max so far: {response.Value}");
                }
            });

            //Prepare request
            foreach (var number in numbersArray)
            {
                Console.WriteLine(
                    $"Client --> Server || Sending number: {number}");
                await request.RequestStream.WriteAsync(
                    new SingleNumberMessage()
                    {
                        Value = number
                    });
                await Task.Delay(random.Next(1, 3) * 1000);
            }
            await request.RequestStream.CompleteAsync();
            //Complete request preparation

            await serverListenerTask;
        }

        private static async Task ClientStreamingCallAsync(
            GrpcChannel channel)
        {
            int[] numbersArray =
            {
                10, 1, 22, -4, 230, 5, 12, 15, 8, 11
            };

            var client = new MessageServices.MessageServicesClient(channel);

            var request = client.GetMaxValue();

            foreach(var number in numbersArray )
            {
                Console.WriteLine($"Sending number: {number}");
                await request.RequestStream.WriteAsync(
                    new SingleNumberMessage()
                    {
                        Value = number
                    });
                await Task.Delay(1000);
            }

            await request.RequestStream.CompleteAsync();
            var response = await request.ResponseAsync;
            Console.WriteLine($"Number received: {response}");
        }

        static async Task ServerStreamingCallAsync(GrpcChannel channel)
        {
            var client = new MessageServices.MessageServicesClient(channel);

            var request = new SingleRequest
            {
                Value = 6
            };

            var stream = client.GetNameList(request);

            await foreach (var s in stream.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(s.Result);
            }
        }
    }
}
