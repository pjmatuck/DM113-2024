using Grpc.Core;
using Messageapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.service
{
    public class MessageServiceImpl : MessageService.MessageServiceBase
    {
        public override async Task Communicate(
            IAsyncStreamReader<RequestMessage> requestStream, 
            IServerStreamWriter<ResponseMessage> responseStream, 
            ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var message = requestStream.Current.Message;
                var result = $"User: {message.User}. Content:{message.Content}\n";
                await responseStream.WriteAsync(new ResponseMessage()
                    { Result = result });
                await Task.Delay(2000);
            }
        }
    }
}
