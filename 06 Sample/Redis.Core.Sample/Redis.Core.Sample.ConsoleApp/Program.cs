using System;
using System.Threading;

namespace Redis.Core.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisHelper redisHelper = new RedisHelper(1);
            redisHelper.KeyDelete("mykey");
            Console.WriteLine("键盘输入:push入队,pop出队");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "push")
                {
                    Console.WriteLine("开始入队");
                    for(int i = 0; i < 100; i++)
                    {
                        redisHelper.ListRightPush("pushQuene", i.ToString());
                    }
                    Console.WriteLine("完成入队");
                }
                else if (input == "pop")
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (redisHelper.ListLength("pushQuene") > 0)
                        {
                            Console.WriteLine(redisHelper.ListLeftPop("pushQuene"));
                        }
                        else { Console.WriteLine("队列为空"); }
                    }
                }
            }
        }
    }
}
