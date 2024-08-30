using Grpc.Core;
using GrpcCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.services
{
    public class CalcServiceImpl : CalcService.CalcServiceBase
    {
        public override Task<Response> Sum(Request request, ServerCallContext context)
        {
            Console.WriteLine($"Sum request received. " +
                $"{request.CalcRequest.ArgA} + {request.CalcRequest.ArgB}");

            var result = new Response()
            {
                Result = 
                    request.CalcRequest.ArgA + request.CalcRequest.ArgB
            };

            return Task.FromResult( result );
        }

        public override Task<Response> Sub(Request request, ServerCallContext context)
        {
            Console.WriteLine($"Sub request received. " +
                $"{request.CalcRequest.ArgA} - {request.CalcRequest.ArgB}");

            var result = new Response()
            {
                Result =
                    request.CalcRequest.ArgA - request.CalcRequest.ArgB
            };

            return Task.FromResult(result);
        }
    }
}
