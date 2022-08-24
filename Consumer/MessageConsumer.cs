﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class MessageConsumer : IConsumer<IMessage>
    {
        public async Task Consume(ConsumeContext<IMessage> context)
            => Console.WriteLine($"Gelen mesaj : {context.Message.Text}");
    }
}
