using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransitProject.Contracts;
using Microsoft.Extensions.Logging;

namespace MassTransitProject.Components.Consumers
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
       readonly ILogger<SubmitOrderConsumer> _logger;
       
        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }


        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.Log(LogLevel.Debug, "SubmitOrderConsumer: {CustomerNumber}", context.Message.CustomerNumber);

            if (context.Message.CustomerNumber.Contains("TEST"))
            {
                await context.RespondAsync<OrderSubmitRejected>(new
                {

                    TimeStamp = InVar.Timestamp,
                    CustomerNumber = "Henrique",
                    motivo = "teste nao encontrou a ordem"
                });

            }


            await context.RespondAsync<OrderSubmitSuccess>(new
            {

                TimeStamp = InVar.Timestamp,
                CustomerNumber = "Henrique",


            }); 
        }

    }
}
