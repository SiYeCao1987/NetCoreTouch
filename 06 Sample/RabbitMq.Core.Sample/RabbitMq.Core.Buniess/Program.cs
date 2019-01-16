using RabbitMq.Core.Model;
using RabbitMq.Core.Service;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace RabbitMq.Core.Buniess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----等待接收消息----");
            RabbitMqConfig mqConfig = new RabbitMqConfig();
            mqConfig.AmqpLists = new List<RabbitMQ.Client.AmqpTcpEndpoint>() { new AmqpTcpEndpoint(new Uri("amqp://192.168.10.244:5672")) };
            mqConfig.UserName = "superrd";
            mqConfig.Password = "superrd";
            mqConfig.VirtualHost = "/";
            mqConfig.ExchangeName = "touchExchange";
            mqConfig.RoutingKey = "touchRoutingKey";
            mqConfig.ExchangeType =ExchangeTypeEnum.direct;
            mqConfig.DurableMessage = true;
            mqConfig.QueueName = "touchQueue";
            mqConfig.DurableQueue = true;

            Program p = new Program();
            RPCBuniessService buniessService = new RPCBuniessService(mqConfig);
            buniessService.ReceiveAndCallBackObject(p.BuniessMothed);
        }

        public BuniessModel BuniessMothed(string name)
        {
            Console.WriteLine("处理消息:" + name);
            return new BuniessModel { name = name };
        }
    }

    class BuniessModel
    {
        public string name { get; set; }
    }
}
