using Grpc.Core;
using Grpc.Net.Client;
using Messageapp;

namespace client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:50005");
            var client = new MessageService.MessageServiceClient(channel);

            var stream = client.Communicate();

            var responseReaderTask = Task.Run(async () =>
            {
                while(await stream.ResponseStream.MoveNext())
                {
                    Console.WriteLine("Client received: " +
                        stream.ResponseStream.Current.Result);
                }
            });

            List<Message> messages = new List<Message>
            {
                new Message { User = "A", Content = "Hello A"},
                new Message { User = "B", Content = "Hello B"},
                new Message { User = "C", Content = "Hello C"}
            };

            foreach (var message in messages)
            {
                Console.WriteLine("Send:" + message);
                await stream.RequestStream.WriteAsync(new RequestMessage()
                {
                    Message = message
                });
                await Task.Delay(1000);
            }

            await stream.RequestStream.CompleteAsync();
            await responseReaderTask;
        }
    }
}
