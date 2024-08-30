using Grpc.Core;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.services
{
    internal class MessageServicesImpl : MessageServices.MessageServicesBase
    {
        List<Message> messages = new List<Message>
        {
            new Message { Id = 0, User = "A", Content = "Olá"},
            new Message { Id = 1, User = "B", Content = "Oi"},
            new Message { Id = 2, User = "C", Content = "Bem vindo"},
            new Message { Id = 3, User = "D", Content = "Hola que tal"},
            new Message { Id = 4, User = "E", Content = "Welcome"}
        };

        public override async Task GetNameList(
            SingleRequest request, 
            IServerStreamWriter<StreamResponse> responseStream, 
            ServerCallContext context)
        {
            var requestValue = request.Value;
            Console.WriteLine("Request received\nItems on list: " 
                + requestValue);

            for(int i = 0; i < requestValue; i++)
            {
                if (i >= messages.Count)
                {
                    Console.WriteLine("Out of bounds. Stop request.");
                    return;
                }

                var response = new StreamResponse
                {
                    Result = messages[i]
                };
                await responseStream.WriteAsync(response);
                await Task.Delay(2000);
            }
        }

        public override async Task<SingleNumberMessage> GetMaxValue(
            IAsyncStreamReader<SingleNumberMessage> requestStream, 
            ServerCallContext context)
        {
            int result = int.MinValue;

            while (await requestStream.MoveNext())
            {
                var singleNumberMessage = requestStream.Current;
                Console.WriteLine($"Number received: " +
                    $"{singleNumberMessage.Value}");

                if (singleNumberMessage.Value > result)
                    result = singleNumberMessage.Value;
            }

            return new SingleNumberMessage()
            {
                Value = result
            };
        }

        public override async Task GetMaxValueRealTime(
            IAsyncStreamReader<SingleNumberMessage> requestStream, 
            IServerStreamWriter<SingleNumberMessage> responseStream, 
            ServerCallContext context)
        {
            int result = int.MinValue;

            await foreach(var request in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"Number received: {request.Value}");
                if(request.Value > result)
                {
                    result = request.Value;
                    await responseStream.WriteAsync(
                        new SingleNumberMessage()
                        {
                            Value = result
                        });
                }
            }
        }
    }
}
