using RabbitMq.Core.Dto;
using RabbitMq.Core.Model;
using RabbitMq.Core.Service;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touch.Utils.Helper;

namespace RabbitMq.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("【----等待发送消息----");
            RabbitMqConfig mqConfig = new RabbitMqConfig();
            mqConfig.AmqpLists = new List<RabbitMQ.Client.AmqpTcpEndpoint>() { new AmqpTcpEndpoint(new Uri("amqp://192.168.10.244:5672")) };
            mqConfig.UserName = "superrd";
            mqConfig.Password = "superrd";
            mqConfig.VirtualHost = "/";
            mqConfig.ExchangeName = "touchExchange";
            mqConfig.RoutingKey = "touchRoutingKey";
            mqConfig.ExchangeType = ExchangeTypeEnum.direct;
            mqConfig.DurableMessage = true;
            while (true)
            {
               
                RPCClientService clientService = new RPCClientService(mqConfig);
                Task<string> t = clientService.SendMsg(Console.ReadLine());
                Console.WriteLine("----消息发送开始----");
                if (!t.Wait(5000))
                {
                    Console.WriteLine("接收消息响应超时");
                }
                else
                {
                    MQRespone res = t.Result.ToString().ToObject<MQRespone>();
                    Console.WriteLine(string.Format("消息状态:{0},消息内容:{1},消息序列号:{2}", res.ResponeStatusEnum, res.Body.message, res.SerialNumber));
                }
                clientService.Close();
                Console.WriteLine("----消息发送结束----】");
                Console.WriteLine("");
                Console.WriteLine("【----等待发送消息----");
            }
        }
    }
}
